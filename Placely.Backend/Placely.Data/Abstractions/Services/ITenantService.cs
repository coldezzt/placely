using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface ITenantService
{
    public Task<Tenant> GetByIdAsNoTrackingAsync(long tenantId);
    public Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId);
    public Task<Tenant> PatchSettingsAsync(Tenant tenant);
    public Task<Tenant> PatchSensitiveSettingsAsync(Tenant tenant);
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
    public Task<Tenant> DeleteAsync(long tenantId);
    public Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId);
}