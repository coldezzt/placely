using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class TenantService(
    ILogger<TenantService> logger,
    ITenantRepository tenantRepo,
    IPropertyRepository propertyRepo) : ITenantService
{
    public async Task<Tenant> GetByIdAsync(long tenantId)
    {
        return await tenantRepo.GetByIdAsync(tenantId);
    }

    public async Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin adding property to favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = await propertyRepo.GetByIdAsync(propertyId);
        
        dbTenant.Favourite.Add(dbProperty);
        
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Trace, "Successfully added property to favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbTenant, dbProperty);
        return dbProperty;
    }
    
    public async Task<List<Property>> GetFavouritePropertiesAsync(long tenantId)
    {
        var dbTenant = await GetByIdAsync(tenantId);
        var favourites = dbTenant.Favourite;
        return favourites;
    }
    
    public async Task<Tenant> PatchSettingsAsync(Tenant tenant)
    {
        logger.Log(LogLevel.Trace, "Begin updating settings for user: {@tenant}", tenant);
        var dbTenant = await tenantRepo.GetByIdAsync(tenant.Id);

        dbTenant.About = tenant.About;
        dbTenant.Work = tenant.Work;
        
        logger.Log(LogLevel.Trace, "Updated settings for user: {@tenant}", tenant);

        var result = await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully updated and saved settings for user: {@tenant}", tenant);
        return result;
    }

    public async Task<Tenant> PatchSensitiveSettingsAsync(Tenant tenant)
    {
        logger.Log(LogLevel.Trace, "Begin updating sensitive settings for user: {@tenant}", tenant);
        var dbTenant = await tenantRepo.GetByIdAsync(tenant.Id);

        dbTenant.Name = tenant.Name;
        dbTenant.PhoneNumber = tenant.PhoneNumber;
        dbTenant.Email = tenant.Email;
        dbTenant.Password = tenant.Password;
        logger.Log(LogLevel.Trace, "Updated sensitive settings for user: {@tenant}", tenant);

        var result = await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully updated and saved sensitive settings for user: {@tenant}", tenant);
        return result;
    }

    public async Task<Tenant> DeleteAsync(long tenantId)
    {
        var dbTenant = await GetByIdAsync(tenantId);
        var result = await tenantRepo.DeleteAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin removing property from favourites." +
                                   "UserId: {userId}. PropertyId: {propertyId}.", tenantId, propertyId);
        
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = dbTenant.Favourite.Find(p => p.Id == propertyId);
        if (dbProperty is null) 
            return new Property();
        
        dbTenant.Favourite.Remove(dbProperty);
        
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Trace, "Successfully removed property from favourites." +
                                   "User: {@tenant}. Property: {@property}.", dbTenant, dbProperty);
        return dbProperty;
    }
}