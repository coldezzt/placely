using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class LandlordService : ILandlordService
{
    public Task<List<Property>> GetOwnedPropertiesAsync(long landlordId)
    {
        throw new NotImplementedException();
    }
}