using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class MessageService(
    IMessageRepository messageRepo) : IMessageService
{
    public async Task<List<Message>> GetMessagesAsync(long chatId)
    {
        return await messageRepo.GetList(chatId);
    }

    public async Task<Message> AddMessageAsync(Message msg)
    {
        var result = await messageRepo.AddAsync(msg);
        await messageRepo.SaveChangesAsync();
        return result;
    }
}