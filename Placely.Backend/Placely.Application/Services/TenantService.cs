using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Application.Services.Utils;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class TenantService(
    ILogger<TenantService> logger,
    ITenantRepository tenantRepo,
    IPropertyRepository propertyRepo) : ITenantService
{
    public async Task<User> GetByIdAsNoTrackingAsync(long tenantId)
    {
        return await tenantRepo.GetByIdAsNoTrackingAsync(tenantId);
    }
    
    public async Task<List<Property>> GetFavouritePropertiesAsync(long tenantId)
    {
        var dbTenant = await GetByIdAsNoTrackingAsync(tenantId);
        var favourites = dbTenant.Favourites;
        return favourites;
    }
    
    public async Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin adding property to favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = await propertyRepo.GetByIdAsync(propertyId);
        
        dbTenant.Favourites.Add(dbProperty);
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully added property to favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbTenant, dbProperty);
        return dbProperty;
    }
    
    public async Task<User> PatchSettingsAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin updating settings for user: {@tenant}", user);
        var dbTenant = await tenantRepo.GetByIdAsync(user.Id);

        dbTenant.About = user.About;
        dbTenant.Work = user.Work;
        var result = await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully updated and saved settings for user: {@tenant}", user);
        return result;
    }

    public async Task<User> PatchSensitiveSettingsAsync(User user)
    {
        logger.Log(LogLevel.Trace, "Begin updating sensitive settings for user: {@tenant}", user);
        var dbTenant = await tenantRepo.GetByIdAsNoTrackingAsync(user.Id);

        dbTenant.Name = user.Name;
        dbTenant.PhoneNumber = user.PhoneNumber;
        dbTenant.Email = user.Email;
        dbTenant.Password = PasswordHasher.Hash(user.Password);
        logger.Log(LogLevel.Trace, "Updated sensitive settings for user: {@tenant}", user);

        var result = await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully updated and saved sensitive settings for user: {@tenant}", user);
        return result;
    }

    public async Task<User> DeleteAsync(long tenantId)
    {
        var dbTenant = await GetByIdAsNoTrackingAsync(tenantId);
        var result = await tenantRepo.DeleteAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin removing property from favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = dbTenant.Favourites.Find(p => p.Id == propertyId);
        if (dbProperty is null) 
            return new Property();
        
        dbTenant.Favourites.Remove(dbProperty);
        
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully removed property from favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbTenant, dbProperty);
        return dbProperty;
    }
}