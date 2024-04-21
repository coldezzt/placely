using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ChatRepository(AppDbContext appDbContext) 
    : Repository<Chat>(appDbContext), IChatRepository
{
    public async Task<List<Chat>> GetListByUserId(long userId)
    {
        var chats = await appDbContext.Chats
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
            .ToListAsync();
        return chats;
    }
}