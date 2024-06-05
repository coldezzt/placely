using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IMessageRepository : IRepository<Message>
{
    public Task<List<Message>> GetListByChatIdAsync(long chatId);
}