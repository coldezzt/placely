using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IAuthorizationService
{
    public Task<string> Authorize(Tenant tenant);
}