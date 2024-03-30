using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class PropertyRepository : IPropertyRepository
{
    public Task<Property> CreateAsync(Property entity)
    {
        throw new NotImplementedException();
    }

    public Property Update(Property entity)
    {
        throw new NotImplementedException();
    }

    public Property Delete(Property entity)
    {
        throw new NotImplementedException();
    }

    public Task<Property?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}