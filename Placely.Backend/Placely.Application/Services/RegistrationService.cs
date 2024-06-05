using Microsoft.Extensions.Logging;
using Placely.Application.Common.Exceptions;
using Placely.Application.Interfaces.Repositories;
using Placely.Application.Services.Utils;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class RegistrationService(
    ILogger<RegistrationService> logger,
    ITenantRepository tenantRepo) : IRegistrationService
{
    public async Task<User> RegisterUserAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin registering user: {@tenant}.", user);
        try
        {
            await tenantRepo.GetByEmailAsync(user.Email);
            
            logger.Log(LogLevel.Information, "Registration failure. User with same email already exists: {@tenant}.", user);
            return new User {Email = ""};
        }
        catch (EntityNotFoundException)
        {
            user.Password = PasswordHasher.Hash(user.Password);
            await tenantRepo.AddAsync(user);
            await tenantRepo.SaveChangesAsync();

            logger.Log(LogLevel.Information, "Successfully registered user: {@tenant}.", user);
            return user;
        }
    }

    public async Task<User> FinalizeUserAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin finalizing user registration. User: {@tenant}.", user);

        var dbTenant = await tenantRepo.GetByEmailAsync(user.Email);

        dbTenant.Password = PasswordHasher.Hash(user.Password);
        dbTenant.PhoneNumber = user.PhoneNumber;
        dbTenant.Name = user.Name;

        await tenantRepo.UpdateAsync(user);
        await tenantRepo.SaveChangesAsync();

        logger.Log(LogLevel.Information, "Successfully finalized user registration. User: {@tenant}.", user);
        return user;
    }
}