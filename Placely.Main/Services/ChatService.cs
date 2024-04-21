using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ChatService(
    IChatRepository chatRepo) : IChatService
{
    public async Task<Chat> GetByIdAsync(long chatId)
    {
        return await chatRepo.GetByIdAsync(chatId);
    }

    public async Task<List<Chat>> GetListByUserIdAsync(long userId)
    {
        return await chatRepo.GetListByUserId(userId);
    }

    public async Task<Chat> CreateAsync(Chat chat)
    {
        chat.DirectoryPath = $"/chat-{chat.FirstUserId}-{chat.SecondUserId}";
        
        var result = await chatRepo.AddAsync(chat);
        await chatRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Chat> DeleteByIdAsync(long chatId)
    {
        var dbChat = await chatRepo.GetByIdAsync(chatId);
        var chat = await chatRepo.DeleteAsync(dbChat);
        return chat;
    }
    
}