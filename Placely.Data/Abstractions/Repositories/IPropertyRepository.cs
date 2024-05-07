using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    public IEnumerable<Property> GetPropertiesByFilter(Func<Property, bool>? predicate = null);
}