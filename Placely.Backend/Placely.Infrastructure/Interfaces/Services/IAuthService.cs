using System.Security.Claims;
using Placely.Application.Common.Models;
using Placely.Infrastructure.Common.Models;

namespace Placely.Infrastructure.Interfaces.Services;

public interface IAuthService
{
    Task<AuthorizationResult> AuthorizeAsync(AuthorizationModel tenant);
    Task<TokenModel> RefreshTokenAsync(TokenModel tokenModel);
    Task<TokenModel> AuthorizeUserFromExternalService(string email, IEnumerable<Claim>? externalClaims);
    Task<TwoFactorAuthenticationModel> ApplyGoogleTwoFactorAuthenticationAsync(string email);
}