using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;
using Placely.Data.Exceptions;

namespace Placely.Data.Repositories;

public class MessageRepository(AppDbContext appDbContext) 
    : Repository<Message>(appDbContext), IMessageRepository
{
    public async Task<List<Message>> GetList(long chatId)
    {
        var dbChat = await appDbContext.Chats
            .Include(chat => chat.Messages)
            .FirstOrDefaultAsync(c => c.Id == chatId);
        
        if (dbChat is null)
            throw new EntityNotFoundException(typeof(Chat), chatId.ToString());

        return dbChat.Messages;
    }
}