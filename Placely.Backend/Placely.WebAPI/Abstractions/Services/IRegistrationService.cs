using Placely.Domain.Entities;

namespace Placely.WebAPI.Abstractions.Services;

public interface IRegistrationService
{
    public Task<Tenant> RegisterUserAsync(Tenant tenant);

    public Task<Tenant> FinalizeUserAsync(Tenant tenant);
}