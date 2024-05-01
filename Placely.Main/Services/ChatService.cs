using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ChatService(
    ILogger<ChatService> logger,
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

    public async Task<Chat> CreateBetweenAsync(long firstUser, long secondUser)
    {
        logger.Log(LogLevel.Trace, "Begin creating chat between: {user1} and {user2}", firstUser, secondUser);

        var dbChat = await chatRepo.TryGetByUsers(firstUser, secondUser);
        if (dbChat is not null)
        {
            logger.Log(LogLevel.Debug, "Chat already exists. Between: {user1} and {user2}", firstUser, secondUser);
            return dbChat;
        }
        
        var chat = new Chat { FirstUserId = firstUser, SecondUserId = secondUser };
        chat.DirectoryPath = "/chat-" + string.Join("-", new List<long> {chat.FirstUserId, chat.SecondUserId}.Order());
        
        var result = await chatRepo.AddAsync(chat);
        await chatRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Trace, "Successfully created chat between: {user1} and {user2}", chat.FirstUserId, chat.SecondUserId);
        return result;
    }

    public async Task<Chat> DeleteByIdAsync(long chatId)
    {
        var dbChat = await chatRepo.GetByIdAsync(chatId);
        var chat = await chatRepo.DeleteAsync(dbChat);
        return chat;
    }
}