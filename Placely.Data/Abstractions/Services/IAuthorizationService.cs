using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Abstractions.Services;

public interface IAuthorizationService
{
    public Task<TokenDto> AuthorizeAsync(Tenant tenant);

    public Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);
}