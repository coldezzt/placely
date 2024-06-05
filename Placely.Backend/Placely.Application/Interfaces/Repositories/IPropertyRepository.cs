using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    public IEnumerable<Property> GetPropertiesByFilter(Func<Property, bool>? predicate = null);
}