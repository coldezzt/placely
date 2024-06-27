using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class ChatService(
    ILogger<ChatService> logger,
    IChatRepository chatRepo,
    IUserRepository userRepo
    ) : IChatService
{
    public async Task<Chat> GetByIdAsync(long chatId)
    {
        return await chatRepo.GetByIdAsNoTrackingAsync(chatId);
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

        var ids = new List<long> {firstUser, secondUser}.Order().ToList();
        var tenants = ids.Select(id => userRepo.GetByIdAsync(id).Result).ToList();
        var chat = new Chat 
        {
            Participants = tenants,
            DirectoryName = "chat-" + string.Join("-", ids)
        };

        var result = await chatRepo.AddAsync(chat);
        await chatRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully created chat between: {user1} and {user2}", firstUser, secondUser);
        return result;
    }

    public async Task<Chat> DeleteByIdAsync(long chatId)
    {
        var dbChat = await chatRepo.GetByIdAsync(chatId);
        var chat = await chatRepo.DeleteAsync(dbChat);
        await chatRepo.SaveChangesAsync();
        return chat;
    }
}