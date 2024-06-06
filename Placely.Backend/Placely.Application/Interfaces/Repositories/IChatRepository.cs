using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IChatRepository : IRepository<Chat>
{
    Task<List<Chat>> GetListByUserId(long userId);
    Task<Chat?> TryGetByUsers(long firstUserId, long secondUserId);
}