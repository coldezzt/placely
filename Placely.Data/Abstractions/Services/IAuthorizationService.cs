using System.Security.Claims;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Abstractions.Services;

public interface IAuthorizationService
{
    public Task<TokenDto> AuthorizeAsync(Tenant tenant);

    public Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);

    public Task<TokenDto> AuthorizeUserFromExternalService(string email,
        IEnumerable<Claim>? externalClaims);
}