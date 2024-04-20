using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Exceptions;
using Placely.Main.Services.Utils;

namespace Placely.Main.Services;

public class RegistrationService(
    ITenantRepository tenantRepo) : IRegistrationService
{
    public async Task<Tenant> RegisterUserAsync(Tenant tenant)
    {
        try
        {
            await tenantRepo.GetByEmailAsync(tenant.Email);
            return new Tenant {Email = tenant.Email};
        }
        catch (EntityNotFoundException ex)
        {
            tenant.Password = PasswordHasher.Hash(tenant.Password);
            await tenantRepo.AddAsync(tenant);
            await tenantRepo.SaveChangesAsync();
            return tenant;
        }
    }
}