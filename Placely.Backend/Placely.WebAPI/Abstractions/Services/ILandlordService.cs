using Placely.Domain.Entities;

namespace Placely.WebAPI.Abstractions.Services;

public interface ILandlordService
{
    public Task<List<Property>> GetOwnedPropertiesAsync(long landlordId);
}