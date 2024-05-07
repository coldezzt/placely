using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface ILandlordService
{
    public Task<List<Property>> GetOwnedPropertiesAsync(long landlordId);
}