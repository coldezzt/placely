using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Application.Common.Exceptions;
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
        
        var dbFirstUser = await appDbContext.Users
            .Include(user => user.Chats)
                .ThenInclude(chat => chat.Participants)
            .FirstOrDefaultAsync(u => u.Id == firstUserId);
        if (dbFirstUser is null)
            throw new EntityNotFoundException(typeof(User), firstUserId.ToString());

        var dbChat = dbFirstUser.Chats.FirstOrDefault(c => 
            c.Participants.Any(p => p.Id == secondUserId));
            
        logger.Log(LogLevel.Debug, dbChat is null 
            ? "Chat with users {firstUserId} and {secondUserId} not found"
            : "Successfully found chat with users {firstUserId} and {secondUserId}",
            firstUserId, secondUserId);
        
        return dbChat;
    }
}