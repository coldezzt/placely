using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface ITenantService
{
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
}