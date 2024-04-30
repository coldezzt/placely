using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ChatRepository(ILogger logger, AppDbContext appDbContext) 
    : Repository<Chat>(logger, appDbContext), IChatRepository
{
    public async Task<List<Chat>> GetListByUserId(long userId)
    {
        logger.Log(LogLevel.Debug, $"Begin getting chats list of user with Id: {userId}");

        var chats = await appDbContext.Chats
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
            .ToListAsync();
        
        logger.Log(LogLevel.Debug, $"Successfully got chats list of user with Id: {userId}");
        return chats;
    }
}