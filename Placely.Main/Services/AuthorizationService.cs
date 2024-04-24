using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;
using Placely.Main.Services.Utils;

namespace Placely.Main.Services;

public class AuthorizationService(
    ITenantRepository tenantRepo,
    IConfiguration configuration) : IAuthorizationService
{
    public async Task<TokenDto> AuthorizeAsync(Tenant tenant)
    {
        var dbTenant = await tenantRepo.GetByEmailAsync(tenant.Email);
        if (!PasswordHasher.Validate(dbTenant.Password, tenant.Password))
            return new TokenDto();

        var tokenDto = await CreateTokenAsync(dbTenant, populateExp: true);
        
        return tokenDto;
    }
    
    public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var tenant = await tenantRepo.GetByEmailAsync(email);

        if (tenant.RefreshToken != tokenDto.RefreshToken
            || tenant.RefreshTokenExpirationDate <= DateTime.Now)
            throw new RefreshTokenBadRequestException();

        return await CreateTokenAsync(tenant, populateExp: false);
    }

    public async Task<TokenDto> AuthorizeUserFromExternalService(
        string email,
        IEnumerable<Claim>? externalClaims = null)
    {
        // Ищем пользователя в бд
        var tenant = await tenantRepo.TryGetByEmailAsync(email) 
                     ?? new Tenant // не нашли - создаём нового, с незаполненными полями (заполняем в другом ендпоинте)
        {
            UserRole = UserRole.Tenant,
            Name = externalClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "",
            Email = email,
            PhoneNumber = "",
            Password = "",
            IsAdditionalRegistrationRequired = true
        };

        var claims = GenerateClaims(tenant).ToList();
        claims.AddRange(externalClaims ?? Array.Empty<Claim>());

        var tokenDto = new TokenDto
        {
            AccessToken = GenerateJwtToken(claims),
            RefreshToken = GenerateRefreshToken()
        };

        tenant.RefreshToken = tokenDto.RefreshToken;
        tenant.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(7);

        await tenantRepo.SaveChangesAsync();
        
        return tokenDto;
    }

    private async Task<TokenDto> CreateTokenAsync(Tenant tenant, bool populateExp)
    {
        var jwtToken = GenerateJwtToken(GenerateClaims(tenant));
        var refreshToken = GenerateRefreshToken();
        tenant.RefreshToken = refreshToken;
        
        if (populateExp)
            tenant.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(7);

        await tenantRepo.SaveChangesAsync();

        return new TokenDto
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken
        };
    }
    
    private string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtAuth:JwtSecurityKey"]!)),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private static IEnumerable<Claim> GenerateClaims(Tenant tenant)
    {
        return new List<Claim>
        {
            new(CustomClaimTypes.UserId, tenant.Id.ToString()),
            new(ClaimTypes.Email, tenant.Email),
            new(CustomClaimTypes.UserRole, tenant.UserRole.ToString()),
        };
    }
    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var jwtSettings = configuration.GetSection("JwtAuth");
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["JwtSecurityKey"]!)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken 
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, 
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}