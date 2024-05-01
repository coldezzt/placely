using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class MessageService(
    ILogger<MessageService> logger,
    IChatRepository chatRepo,
    IMessageRepository messageRepo,
    IWebHostEnvironment env) : IMessageService
{
    public async Task<List<Message>> GetListAsync(long chatId)
    {
        return await messageRepo.GetListByChatIdAsync(chatId);
    }

    public async Task<Message> AddAsync(Message msg)
    {
        var result = await messageRepo.AddAsync(msg);
        await messageRepo.SaveChangesAsync();
        return result;
    }

    public async Task<List<string>> GetFilesListAsync(long chatId)
    {
        var messages = await messageRepo.GetListByChatIdAsync(chatId);
        var paths = messages.Where(m => m.FilePath is not null).Select(m => m.FilePath).ToList();
        return paths!;
    }
    
    public async Task<byte[]> GetFileBytesAsync(string filePath)
    {
        var fileBytes = await File.ReadAllBytesAsync(filePath);
        return fileBytes;
    }
    
    public async Task<string> UploadFileAsync(long chatId, long messageId, IFormFile file)
    {
        var chat = await chatRepo.GetByIdAsync(chatId);
        
        var filePath = Path.Combine(chat.DirectoryPath, file.Name);
        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);

        return filePath;
    }

    public async Task<string> DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(env.WebRootPath, filePath);
        if (!Path.Exists(fullPath))
            return fullPath;
        
        File.Delete(fullPath);
        return fullPath;
    }
}