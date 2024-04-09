using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ChatRepository : IChatRepository
{
    public Task<Chat> CreateAsync(Chat entity)
    {
        throw new NotImplementedException();
    }

    public Chat Update(Chat entity)
    {
        throw new NotImplementedException();
    }

    public Chat Delete(Chat entity)
    {
        throw new NotImplementedException();
    }

    public Task<Chat?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}