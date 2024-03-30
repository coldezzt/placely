using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class TenantRepository : ITenantRepository
{
    public Task<Tenant> CreateAsync(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Tenant Update(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Tenant Delete(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task<Tenant?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}