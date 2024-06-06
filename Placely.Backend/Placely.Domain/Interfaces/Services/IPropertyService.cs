using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IPropertyService
{
    Task<Property> GetByIdAsNoTrackingAsync(long propertyId);
    Task<Property> AddAsync(Property property);
    Task<Property> UpdateAsync(Property property);
    Task<Property> DeleteAsync(long propertyId);
    Task<List<Property>> GetChunkByFilterAsync(Dictionary<SearchParameterType, string> searchParameters,
        int extraLoadNumber, int amount);
    Task<List<string>> GetAddressSuggestionAsync(string address);
}