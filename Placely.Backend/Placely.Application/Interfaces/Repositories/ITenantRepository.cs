using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface ITenantRepository : IRepository<User>
{
    public Task<User> GetByEmailAsync(string email);

    public Task<User?> TryGetByEmailAsync(string email);

    public Task<User> AddOrUpdateAsync(User user);
}