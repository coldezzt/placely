using System.Security.Claims;
using Placely.Data.Dtos;
using Placely.Data.Models;

namespace Placely.Data.Abstractions.Services;

public interface IAuthorizationService
{
    public Task<AuthorizationResult> AuthorizeAsync(AuthorizationDto dto);

    public Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);

    public Task<TokenDto> AuthorizeUserFromExternalService(string email,
        IEnumerable<Claim>? externalClaims);

    public Task<TwoFactorAuthenticationModel> ApplyGoogleTwoFactorAuthenticationAsync(string email);
}