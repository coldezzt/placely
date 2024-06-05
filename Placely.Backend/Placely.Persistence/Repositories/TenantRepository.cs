using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Placely.Application.Common.Exceptions;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class TenantRepository(ILogger<TenantRepository> logger, AppDbContext appDbContext) 
    : Repository<User>(logger, appDbContext), ITenantRepository
{
    public async Task<User> GetByEmailAsync(string email)
    {
        var result = await TryGetByEmailAsync(email);
        if (result is null)
            throw new EntityNotFoundException(typeof(User), email);
        
        return result;
    }

    public async Task<User?> TryGetByEmailAsync(string email)
    {
        logger.Log(LogLevel.Debug, $"Begin getting user by email: {email}");

        var result = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == email);

        logger.Log(LogLevel.Debug, $"Successfully got user by email: {email}");
        return result;
    }

    public async Task<User> AddOrUpdateAsync(User user)
    {
        logger.Log(LogLevel.Information, "Begin adding or updating user according to it's existing. User: {@tenant}", user);
        var dbTenant = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == user.Email);
        EntityEntry<User> resultTenantEntry;
        if (dbTenant is null)
        {
            resultTenantEntry = await appDbContext.Tenants.AddAsync(user);
            logger.Log(LogLevel.Information, "Successfully created user according to it's nonexistence. " +
                                             "User: {@resultTenant}", resultTenantEntry.Entity);
        }
        else
        {
            resultTenantEntry = appDbContext.Tenants.Update(user);
            logger.Log(LogLevel.Information, "Successfully updated user according to it's existence. " +
                                             "User: {@resultTenant}", resultTenantEntry.Entity);
        }

        return resultTenantEntry.Entity;
    }
}