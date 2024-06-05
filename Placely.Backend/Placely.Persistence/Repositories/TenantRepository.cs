using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Placely.Application.Common.Exceptions;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class UserRepository(ILogger<UserRepository> logger, AppDbContext appDbContext) 
    : Repository<User>(logger, appDbContext), IUserRepository
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
        logger.Log(LogLevel.Trace, $"Begin getting user by email: {email}");

        var result = await appDbContext.Users.FirstOrDefaultAsync(t => t.Email == email);

        logger.Log(LogLevel.Debug, $"Successfully got user by email: {email}");
        
        return result;
    }

    public async Task<User> AddOrUpdateAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin adding or updating user according to it's existing. User: {@tenant}", user);
        
        var dbUser = await appDbContext.Users.FirstOrDefaultAsync(t => t.Email == user.Email);
        EntityEntry<User> resultUserEntry;
        if (dbUser is null)
        {
            resultUserEntry = await appDbContext.Users.AddAsync(user);
            
            logger.Log(LogLevel.Debug, "Successfully created user according to it's nonexistence. " +
                                             "User: {@resultTenant}", resultUserEntry.Entity);
        }
        else
        {
            resultUserEntry = appDbContext.Users.Update(user);
            
            logger.Log(LogLevel.Debug, "Successfully updated user according to it's existence. " +
                                             "User: {@resultTenant}", resultUserEntry.Entity);
        }

        return resultUserEntry.Entity;
    }
}