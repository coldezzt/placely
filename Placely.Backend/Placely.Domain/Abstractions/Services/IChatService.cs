using Placely.Domain.Entities;

namespace Placely.Domain.Abstractions.Services;

public interface IChatService
{
    public Task<Chat> GetByIdAsync(long chatId);
    public Task<List<Chat>> GetListByUserIdAsync(long userId);
    public Task<Chat> CreateBetweenAsync(long firstUser, long secondUser);
    public Task<Chat> DeleteByIdAsync(long chatId);
}