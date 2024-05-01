using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;
using Placely.Data.Exceptions;

namespace Placely.Data.Repositories;

public class TenantRepository(ILogger<TenantRepository> logger, AppDbContext appDbContext) 
    : Repository<Tenant>(logger, appDbContext), ITenantRepository
{
    public async Task<Tenant> GetByEmailAsync(string email)
    {
        var result = await TryGetByEmailAsync(email);
        if (result is null)
            throw new EntityNotFoundException(typeof(Tenant), email);
        
        return result;
    }

    public async Task<Tenant?> TryGetByEmailAsync(string email)
    {
        logger.Log(LogLevel.Debug, $"Begin getting user by email: {email}");

        var result = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == email);

        logger.Log(LogLevel.Debug, $"Successfully got user by email: {email}");
        return result;
    }

    public async Task<Tenant> AddOrUpdateAsync(Tenant tenant)
    {
        logger.Log(LogLevel.Information, "Begin adding or updating user according to it's existing. User: {@tenant}", tenant);
        var dbTenant = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == tenant.Email);
        EntityEntry<Tenant> resultTenantEntry;
        if (dbTenant is null)
        {
            resultTenantEntry = await appDbContext.Tenants.AddAsync(tenant);
            logger.Log(LogLevel.Information, "Successfully created user according to it's nonexistence. " +
                                             "User: {@resultTenant}", resultTenantEntry.Entity);
        }
        else
        {
            resultTenantEntry = appDbContext.Tenants.Update(tenant);
            logger.Log(LogLevel.Information, "Successfully updated user according to it's existence. " +
                                             "User: {@resultTenant}", resultTenantEntry.Entity);
        }

        return resultTenantEntry.Entity;
    }
}