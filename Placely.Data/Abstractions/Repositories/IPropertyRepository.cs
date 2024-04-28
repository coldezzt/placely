using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    public IQueryable<Property> GetPropertiesByFilter(Func<Property, bool>? predicate = null);
    public Task<List<Review>> GetListByPropertyIdAsync(long propertyId);
}