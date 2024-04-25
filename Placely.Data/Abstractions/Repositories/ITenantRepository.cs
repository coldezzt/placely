using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface ITenantRepository : IRepository<Tenant>
{
    public Task<Tenant> GetByEmailAsync(string email);

    public Task<Tenant?> TryGetByEmailAsync(string email);

    public Task<Tenant> AddOrUpdateAsync(Tenant tenant);
}