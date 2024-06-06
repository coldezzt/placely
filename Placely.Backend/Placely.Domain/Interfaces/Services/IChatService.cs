using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IChatService
{
    Task<Chat> GetByIdAsync(long chatId);
    Task<List<Chat>> GetListByUserIdAsync(long userId);
    Task<Chat> CreateBetweenAsync(long firstUser, long secondUser);
    Task<Chat> DeleteByIdAsync(long chatId);
}