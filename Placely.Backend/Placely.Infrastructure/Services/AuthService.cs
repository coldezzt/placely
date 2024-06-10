using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Google.Authenticator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Placely.Application.Common.Exceptions;
using Placely.Application.Common.Models;
using Placely.Application.Interfaces.Repositories;
using Placely.Application.Services.Utils;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Infrastructure.Common.Models;
using Placely.Infrastructure.Interfaces.Services;
using AuthorizationResult = Placely.Infrastructure.Common.Models.AuthorizationResult;

namespace Placely.Infrastructure.Services;

public class AuthService(
    ILogger<AuthService> logger,
    IUserRepository tenantRepo,
    IConfiguration configuration) : IAuthService
{
    public async Task<AuthorizationResult> AuthorizeAsync(AuthorizationModel tenant)
    {
        logger.Log(LogLevel.Trace, "Begin authorize user with email {Email}", tenant.Email);
        
        var dbUser = await tenantRepo.GetByEmailAsync(tenant.Email);
        if (!PasswordHasher.IsValid(dbUser.Password, tenant.Password))
        {
            logger.Log(LogLevel.Debug, "Authorization user with email {Email} failed due to: wrong password.", tenant.Email);
            
            return new AuthorizationResult { IsSuccess = false, Error = "Неверный пароль!" };
        }

        if (dbUser.IsTwoFactorEnabled)
        {
            var tfa = new TwoFactorAuthenticator();
            if (!tfa.ValidateTwoFactorPIN(dbUser.TwoFactorAccountSecretKey, tenant.TwoFactorKey))
            {
                logger.Log(LogLevel.Debug, "Authorization user with email {Email} failed due to: wrong 2FA TOTP key.", tenant.Email);
                
                return new AuthorizationResult { IsSuccess = false, Error = "Неверный двухфакторный ключ!" };
            }
        }

        var tokenDto = await CreateTokenAsync(dbUser, populateExp: true);
        
        logger.Log(LogLevel.Debug, "Successfully authorized user with email {Email}.", tenant.Email);
        
        return new AuthorizationResult { IsSuccess = true, TokenModel = tokenDto };
    }
    
    public async Task<TokenModel> RefreshTokenAsync(TokenModel tokenDto)
    {
        logger.Log(LogLevel.Trace, "Begin refreshing user tokens with expired access token {accessToken}", tokenDto.AccessToken);
        
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var tenant = await tenantRepo.GetByEmailAsync(email!);

        if (tenant.RefreshToken != tokenDto.RefreshToken
            || tenant.RefreshTokenExpirationDate <= DateTime.Now)
            throw new RefreshTokenBadRequestException();
        
        var newTokenPair = await CreateTokenAsync(tenant, populateExp: false);
        
        logger.Log(LogLevel.Debug, "Successfully refresh user tokens with expired access token {accessToken}", tokenDto.AccessToken);
        
        return newTokenPair;
    }

    public async Task<TokenModel> AuthorizeUserFromExternalService(string email,
        IEnumerable<Claim>? externalClaims = null)
    {
        logger.Log(LogLevel.Trace, "Begin authorizing user with {Email} using external service.", email);

        // Ищем пользователя в бд - если нет создаём нового
        var tenant = await tenantRepo.TryGetByEmailAsync(email) ?? new User
        {
            UserRole = UserRoleType.Tenant,
            Email = email,
            Name = externalClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "",
            IsAdditionalRegistrationRequired = true,
            PhoneNumber = "",
            Password = ""
        };

        var claims = GenerateClaims(tenant).ToList();
        claims.AddRange(externalClaims ?? Array.Empty<Claim>());

        var tokenDto = new TokenModel
        {
            AccessToken = GenerateJwtToken(claims),
            RefreshToken = GenerateRefreshToken()
        };

        tenant.RefreshToken = tokenDto.RefreshToken;
        tenant.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(7);

        await tenantRepo.AddOrUpdateAsync(tenant);
        await tenantRepo.SaveChangesAsync();
        logger.Log(LogLevel.Debug, "Successfully authorize user with {Email} using external service.", email);

        return tokenDto;
    }

    public async Task<TwoFactorAuthenticationModel> ApplyGoogleTwoFactorAuthenticationAsync(string email)
    {
        logger.Log(LogLevel.Trace, "Begin applying 2FA to user with {Email}.", email);

        var tenant = await tenantRepo.GetByEmailAsync(email);

        if (tenant.IsTwoFactorEnabled)
        {
            logger.Log(LogLevel.Debug, "2FA already applied to user with {Email}.", email);
            
            return new TwoFactorAuthenticationModel
            {
                ManualEntryKey = tenant.ManualEntryKey!,
                QrImageUrl = tenant.QrImageUrl!
            };
        }

        logger.Log(LogLevel.Trace, "Begin setting up TOTP code generation tokens for user with {Email}.", email);
        
        var key = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(key);
        var accountSecretKey = Convert.ToBase64String(key);

        var tfa = new TwoFactorAuthenticator();
        var setupInfo = tfa.GenerateSetupCode("Placely & You", email, accountSecretKey, false);
        
        logger.Log(LogLevel.Trace, "Successfully setup TOTP code generation tokens for user with email {Email}.", email);

        tenant.IsTwoFactorEnabled = true;
        tenant.QrImageUrl = setupInfo.QrCodeSetupImageUrl;
        tenant.ManualEntryKey = setupInfo.ManualEntryKey;
        tenant.TwoFactorAccountSecretKey = accountSecretKey;

        await tenantRepo.AddOrUpdateAsync(tenant);
        await tenantRepo.SaveChangesAsync();

        logger.Log(LogLevel.Debug, "Successfully apply 2FA to user with {Email}.", email);
        
        return new TwoFactorAuthenticationModel
        {
            ManualEntryKey = tenant.ManualEntryKey,
            QrImageUrl = tenant.QrImageUrl
        };
    }
    
    private async Task<TokenModel> CreateTokenAsync(User user, bool populateExp)
    {
        logger.Log(LogLevel.Trace, "Begin creating tokens pair for user with email: {email}", user.Email);
        
        var jwtToken = GenerateJwtToken(GenerateClaims(user));
        var refreshToken = GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        if (populateExp) user.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(7);

        await tenantRepo.SaveChangesAsync();

        var tokenDto = new TokenModel
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken
        };
        
        logger.Log(LogLevel.Debug, "Successfully created tokens pair for user with email: {email}", user.Email);
        
        return tokenDto;
    }
    
    private string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var claimsList = claims.ToList();
        var jwt = new JwtSecurityToken(
            claims: claimsList,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtAuth:JwtSecurityKey"]!)),
                SecurityAlgorithms.HmacSha256
            )
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return token;
    }

    private IEnumerable<Claim> GenerateClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(CustomClaimTypes.UserId, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? ""),
            new(ClaimTypes.Role, user.UserRole.ToString()),
        };

        logger.Log(LogLevel.Trace, "Successfully created server-side claims by user with {Email}", user.Email);
        
        return claims;
    }
    
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        logger.Log(LogLevel.Trace, "Begin extracting claims from expired token - {token}", token);

        var jwtSettings = configuration.GetSection("JwtAuth");
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["JwtSecurityKey"]!)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken 
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, 
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        logger.Log(LogLevel.Debug, "Successfully extracted claims from expired token - {token}", token);
        
        return principal;
    }
    
    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var token = Convert.ToBase64String(randomNumber);
        
        return token;
    }
}