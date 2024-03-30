using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class PropertyOptionRepository : IPropertyOptionRepository
{
    public Task<PropertyOption> CreateAsync(PropertyOption entity)
    {
        throw new NotImplementedException();
    }

    public PropertyOption Update(PropertyOption entity)
    {
        throw new NotImplementedException();
    }

    public PropertyOption Delete(PropertyOption entity)
    {
        throw new NotImplementedException();
    }

    public Task<PropertyOption?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}