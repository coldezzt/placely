using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IPropertyService
{
    public Task<Property> GetByIdAsNoTrackingAsync(long propertyId);
    public Task<Property> AddAsync(Property property);
    public Task<Property> UpdateAsync(Property property);
    public Task<Property> DeleteAsync(long propertyId);
    public Task<List<Property>> GetChunkByFilterAsync(Dictionary<SearchParameterType, string> searchParameters,
        int extraLoadNumber, int amount);
    public Task<List<string>> GetAddressSuggestionAsync(string address);
}