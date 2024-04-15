using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class TenantService : ITenantService
{
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId)
    {
        throw new NotImplementedException();
    }
}