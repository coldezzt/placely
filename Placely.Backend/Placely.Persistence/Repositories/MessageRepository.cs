using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Application.Exceptions;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class MessageRepository(ILogger<MessageRepository> logger, AppDbContext appDbContext) 
    : Repository<Message>(logger, appDbContext), IMessageRepository
{
    public async Task<List<Message>> GetListByChatIdAsync(long chatId)
    {
        logger.Log(LogLevel.Debug, $"Begin getting messages list of chat with Id: {chatId}");

        var dbChat = await appDbContext.Chats
            .Include(static chat => chat.Messages)
            .FirstOrDefaultAsync(c => c.Id == chatId);
        
        if (dbChat is null)
            throw new EntityNotFoundException(typeof(Chat), chatId.ToString());

        logger.Log(LogLevel.Debug, $"Successfully got messages list of chat with Id: {chatId}");
        return dbChat.Messages;
    }
}