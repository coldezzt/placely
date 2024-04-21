using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IMessageService
{
    public Task<List<Message>> GetMessagesAsync(long chatId);
    public Task<Message> AddMessageAsync(Message msg);
}