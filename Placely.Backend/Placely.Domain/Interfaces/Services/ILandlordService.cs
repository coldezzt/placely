using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface ILandlordService
{
    public Task<List<Property>> GetOwnedPropertiesAsync(long landlordId);
}