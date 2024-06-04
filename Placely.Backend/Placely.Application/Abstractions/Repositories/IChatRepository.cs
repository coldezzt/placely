using Placely.Domain.Entities;

namespace Placely.Application.Abstractions.Repositories;

public interface IChatRepository : IRepository<Chat>
{
    public Task<List<Chat>> GetListByUserId(long userId);
    public Task<Chat?> TryGetByUsers(long firstUserId, long secondUserId);
}