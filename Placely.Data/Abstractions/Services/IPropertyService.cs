using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Abstractions.Services;

public interface IPropertyService
{
    public Task<Property> GetByIdAsync(long propertyId);
    public Task<Property> AddAsync(Property property);
    public Task<Property> UpdateAsync(Property property);
    public Task<Property> DeleteAsync(long propertyId);
    public Task<List<Property>> GetChunkByFilterAsync(Dictionary<SearchParameter, string> searchParameters,
        int extraLoadNumber, int amount);
    public Task<List<Review>> GetListByPropertyIdAsync(long propertyId, int extraLoadNumber);
}