using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Application.Services.Utils;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class UserService(
    ILogger<UserService> logger,
    IUserRepository tenantRepo,
    IPropertyRepository propertyRepo) : IUserService
{
    public async Task<User> GetByIdAsNoTrackingAsync(long tenantId)
    {
        return await tenantRepo.GetByIdAsNoTrackingAsync(tenantId);
    }
    
    public async Task<List<Property>> GetFavouritePropertiesAsync(long tenantId)
    {
        var dbUser = await GetByIdAsNoTrackingAsync(tenantId);
        var favourites = dbUser.Favourites;
        return favourites;
    }
    
    public async Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin adding property to favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        var dbUser = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = await propertyRepo.GetByIdAsync(propertyId);
        
        dbUser.Favourites.Add(dbProperty);
        await tenantRepo.UpdateAsync(dbUser);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully added property to favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbUser, dbProperty);
        return dbProperty;
    }
    
    public async Task<User> PatchSettingsAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin updating settings for user: {@tenant}", user);
        var dbUser = await tenantRepo.GetByIdAsync(user.Id);

        dbUser.About = user.About;
        dbUser.Work = user.Work;
        var result = await tenantRepo.UpdateAsync(dbUser);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully updated and saved settings for user: {@tenant}", user);
        return result;
    }

    public async Task<User> PatchSensitiveSettingsAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin updating sensitive settings for user: {@tenant}", user);
        var dbUser = await tenantRepo.GetByIdAsNoTrackingAsync(user.Id);

        dbUser.Name = user.Name;
        dbUser.PhoneNumber = user.PhoneNumber;
        dbUser.Email = user.Email;
        dbUser.Password = PasswordHasher.Hash(user.Password);
        logger.Log(LogLevel.Trace, "Updated sensitive settings for user: {@tenant}", user);

        var result = await tenantRepo.UpdateAsync(dbUser);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully updated and saved sensitive settings for user: {@tenant}", user);
        return result;
    }

    public async Task<User> DeleteAsync(long tenantId)
    {
        var dbUser = await GetByIdAsNoTrackingAsync(tenantId);
        var result = await tenantRepo.DeleteAsync(dbUser);
        await tenantRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin removing property from favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        
        var dbUser = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = dbUser.Favourites.Find(p => p.Id == propertyId);
        if (dbProperty is null) 
            return new Property
            {
                OwnerId = 0,
                PriceListId = 0,
                Address = null,
                Description = null,
                Type = PropertyType.Hostel,
                PublicationDate = default
            };
        
        dbUser.Favourites.Remove(dbProperty);
        
        await tenantRepo.UpdateAsync(dbUser);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully removed property from favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbUser, dbProperty);
        return dbProperty;
    }
}