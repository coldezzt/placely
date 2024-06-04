using Placely.Domain.Entities;

namespace Placely.Application.Abstractions.Repositories;

public interface IMessageRepository : IRepository<Message>
{
    public Task<List<Message>> GetListByChatIdAsync(long chatId);
}