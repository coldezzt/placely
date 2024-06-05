using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class ChatRepository(ILogger<ChatRepository> logger, AppDbContext appDbContext) 
    : Repository<Chat>(logger, appDbContext), IChatRepository
{
    public async Task<List<Chat>> GetListByUserId(long userId)
    {
        logger.Log(LogLevel.Trace, $"Begin getting chats list of user with Id: {userId}");

        var chats = await appDbContext.Chats
            .Where(c => c.Participants.Any(t => t.Id == userId))
            .ToListAsync();
        
        logger.Log(LogLevel.Debug, $"Successfully got chats list of user with Id: {userId}");
        
        return chats;
    }

    public async Task<Chat?> TryGetByUsers(long firstUserId, long secondUserId)
    {
        logger.Log(LogLevel.Trace, "Begin getting chat with users: " +
                                   "{firstUserId} and {secondUserId}", firstUserId, secondUserId);

        var ids = new List<long> {firstUserId, secondUserId};
        var dbChat = await appDbContext.Chats.FirstOrDefaultAsync(c => 
            c.Participants
                .Select(p => p.Id).Order()
                .SequenceEqual(ids.Order())
            );
        
        logger.Log(LogLevel.Debug, dbChat is null 
            ? "Chat with users {firstUserId} and {secondUserId} not found"
            : "Successfully found chat with users {firstUserId} and {secondUserId}",
            firstUserId, secondUserId);
        
        return dbChat;
    }
}