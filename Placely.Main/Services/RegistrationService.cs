using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Exceptions;
using Placely.Main.Services.Utils;

namespace Placely.Main.Services;

public class RegistrationService(
    ITenantRepository tenantRepo) : IRegistrationService
{
    // TODO: добавить проверку на номер телефона
    public async Task<Tenant> RegisterUserAsync(Tenant tenant)
    {
        try
        {
            await tenantRepo.GetByEmailAsync(tenant.Email);
            return new Tenant {Email = tenant.Email};
        }
        catch (EntityNotFoundException)
        {
            tenant.Password = PasswordHasher.Hash(tenant.Password);
            await tenantRepo.AddAsync(tenant);
            await tenantRepo.SaveChangesAsync();
            return tenant;
        }
    }

    public async Task<Tenant> FinalizeUserAsync(Tenant tenant)
    {
        var dbTenant = await tenantRepo.GetByEmailAsync(tenant.Email);

        dbTenant.Password = PasswordHasher.Hash(tenant.Password);
        dbTenant.PhoneNumber = tenant.PhoneNumber;
        dbTenant.Name = tenant.Name;

        await tenantRepo.UpdateAsync(tenant);
        await tenantRepo.SaveChangesAsync();

        return tenant;
    }
}