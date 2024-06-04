using System.Security.Claims;
using Placely.Application.Models;

namespace Placely.Domain.Abstractions.Services;

public interface IAuthService
{
    public Task<AuthorizationResult> AuthorizeAsync(AuthorizationModel tenant);

    public Task<TokenModel> RefreshTokenAsync(TokenModel tokenDto);

    public Task<TokenModel> AuthorizeUserFromExternalService(string email,
        IEnumerable<Claim>? externalClaims);

    public Task<TwoFactorAuthenticationModel> ApplyGoogleTwoFactorAuthenticationAsync(string email);
}