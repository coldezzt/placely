using Placely.Domain.Entities;

namespace Placely.WebAPI.Abstractions.Services;

public interface IMessageService
{
    public Task<List<Message>> GetListAsync(long chatId);
    public Task<Message> AddAsync(Message msg);
    public Task<List<string>> GetListFileNamesAsync(long chatId);
    public Task<byte[]> GetFileBytesFromChatAsync(long chatId, string fileName);
    public Task<string> AddFileToMessageAsync(long messageId, IFormFile file);
    public Task<string> DeleteFileFromChatAsync(long chatId, string fileName);
}