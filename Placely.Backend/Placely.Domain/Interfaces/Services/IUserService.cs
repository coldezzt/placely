using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> GetByIdAsNoTrackingAsync(long tenantId);
    Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId);
    Task<User> PatchSettingsAsync(User user);
    Task<User> PatchSensitiveSettingsAsync(User user);
    Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
    Task<User> DeleteAsync(long tenantId);
    Task<Property> DeletePropertyFromFavouritesAsync(long tenantId, long propertyId);
}