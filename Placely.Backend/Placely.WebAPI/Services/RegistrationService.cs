using Placely.Application.Abstractions.Repositories;
using Placely.Application.Exceptions;
using Placely.Domain.Entities;
using Placely.WebAPI.Abstractions.Services;
using Placely.WebAPI.Services.Utils;

namespace Placely.WebAPI.Services;

public class RegistrationService(
    ILogger<RegistrationService> logger,
    ITenantRepository tenantRepo) : IRegistrationService
{
    public async Task<Tenant> RegisterUserAsync(Tenant tenant)
    {
        logger.Log(LogLevel.Trace, "Begin registering user: {@tenant}.", tenant);
        try
        {
            await tenantRepo.GetByEmailAsync(tenant.Email);
            
            logger.Log(LogLevel.Information, "Registration failure. User with same email already exists: {@tenant}.", tenant);
            return new Tenant {Email = ""};
        }
        catch (EntityNotFoundException)
        {
            tenant.Password = PasswordHasher.Hash(tenant.Password);
            await tenantRepo.AddAsync(tenant);
            await tenantRepo.SaveChangesAsync();

            logger.Log(LogLevel.Information, "Successfully registered user: {@tenant}.", tenant);
            return tenant;
        }
    }

    public async Task<Tenant> FinalizeUserAsync(Tenant tenant)
    {
        logger.Log(LogLevel.Trace, "Begin finalizing user registration. User: {@tenant}.", tenant);

        var dbTenant = await tenantRepo.GetByEmailAsync(tenant.Email);

        dbTenant.Password = PasswordHasher.Hash(tenant.Password);
        dbTenant.PhoneNumber = tenant.PhoneNumber;
        dbTenant.Name = tenant.Name;

        await tenantRepo.UpdateAsync(tenant);
        await tenantRepo.SaveChangesAsync();

        logger.Log(LogLevel.Information, "Successfully finalized user registration. User: {@tenant}.", tenant);
        return tenant;
    }
}