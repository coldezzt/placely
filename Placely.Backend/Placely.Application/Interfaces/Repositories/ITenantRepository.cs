using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User> GetByEmailAsync(string email);

    public Task<User?> TryGetByEmailAsync(string email);

    public Task<User> AddOrUpdateAsync(User user);
}