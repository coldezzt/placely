using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IRegistrationService
{
    public Task<Tenant> RegisterUserAsync(Tenant tenant);
}