using System.Security.Claims;
using Placely.WebAPI.Dto;
using Placely.WebAPI.Models;

namespace Placely.WebAPI.Abstractions.Services;

public interface IAuthService
{
    public Task<AuthorizationResult> AuthorizeAsync(AuthorizationDto dto);

    public Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);

    public Task<TokenDto> AuthorizeUserFromExternalService(string email,
        IEnumerable<Claim>? externalClaims);

    public Task<TwoFactorAuthenticationModel> ApplyGoogleTwoFactorAuthenticationAsync(string email);
}