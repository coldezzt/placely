using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class MessageRepository : IMessageRepository
{
    public Task<Message> CreateAsync(Message entity)
    {
        throw new NotImplementedException();
    }

    public Message Update(Message entity)
    {
        throw new NotImplementedException();
    }

    public Message Delete(Message entity)
    {
        throw new NotImplementedException();
    }

    public Task<Message?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}