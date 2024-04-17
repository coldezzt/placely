using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface ITenantRepository : IRepository<Tenant>
{
    public Task<Tenant> GetByEmailAsync(string email);
}