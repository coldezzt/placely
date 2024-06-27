using Microsoft.AspNetCore.Http;
using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IMessageService
{
    Task<List<Message>> GetListAsync(long chatId);
    Task<Message> AddAsync(Message msg);
    Task<List<string>> GetListFileNamesAsync(long chatId);
    Task<byte[]> GetFileBytesFromChatAsync(long chatId, string fileName);
    Task<string> AddFileToMessageAsync(long messageId, IFormFile file);
    Task<string> DeleteFileFromChatAsync(long chatId, string fileName);
}