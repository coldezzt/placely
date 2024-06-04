using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IChatRepository : IRepository<Chat>
{
    public Task<List<Chat>> GetListByUserId(long userId);
    public Task<Chat?> TryGetByUsers(long firstUserId, long secondUserId);
}