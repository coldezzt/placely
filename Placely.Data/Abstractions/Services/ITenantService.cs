using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface ITenantService
{
    public Task<Tenant> GetByIdAsync(long tenantId);
    public Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId);
    public Task<Tenant> ChangeSettingsAsync(Tenant tenant); 
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
    public Task<Tenant> DeleteAsync(long tenantId);
    public Task<Property> RemovePropertyFromFavouritesAsync(long tenantId, long propertyId);
}