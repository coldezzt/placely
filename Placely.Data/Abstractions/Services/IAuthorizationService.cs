using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IAuthorizationService
{
    public Task<Tenant> Register(Tenant tenant);
    public Task<Tenant> Authorize(Tenant tenant);
}