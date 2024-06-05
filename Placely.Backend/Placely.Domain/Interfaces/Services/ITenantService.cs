using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface ITenantService
{
    public Task<User> GetByIdAsNoTrackingAsync(long tenantId);
    public Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId);
    public Task<User> PatchSettingsAsync(User user);
    public Task<User> PatchSensitiveSettingsAsync(User user);
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
    public Task<User> DeleteAsync(long tenantId);
    public Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId);
}