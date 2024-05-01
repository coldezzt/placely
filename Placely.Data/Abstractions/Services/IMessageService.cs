using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IMessageService
{
    public Task<List<Message>> GetListAsync(long chatId);
    public Task<Message> AddAsync(Message msg);
    public Task<List<string>> GetFilesListAsync(long chatId);
    public Task<byte[]> GetFileBytesAsync(string filePath);
    public Task<string> UploadFileAsync(long chatId, long messageId, IFormFile file);
    public Task<string> DeleteFileAsync(string filePath);
}