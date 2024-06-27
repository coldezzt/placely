using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);

    Task<User?> TryGetByEmailAsync(string email);

    Task<User> AddOrUpdateAsync(User user);
}