using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IMessageRepository : IRepository<Message>
{
    public Task<List<Message>> GetList(long chatId);
}