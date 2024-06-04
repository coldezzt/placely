using Placely.Domain.Entities;

namespace Placely.Domain.Abstractions.Services;

public interface ILandlordService
{
    public Task<List<Property>> GetOwnedPropertiesAsync(long landlordId);
}