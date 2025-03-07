﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Placely.Application.Common.Options;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class MessageService(
    ILogger<MessageService> logger,
    IOptions<CommonOptions> options,
    IChatRepository chatRepo,
    IMessageRepository messageRepo) 
    : IMessageService
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

    public async Task<List<string>> GetListFileNamesAsync(long chatId)
    {
        logger.Log(LogLevel.Trace, "Begin getting all file names from chat. ChatId: {chatId}.", chatId);
        
        var messages = await messageRepo.GetListByChatIdAsync(chatId);
        var fileNames = messages
            .Where(m => m.FileName is not (null or ""))
            .Select(m => m.FileName ?? "").ToList();
        
        logger.Log(LogLevel.Debug, "Successfully got all file names from chat. Names: {@fileNames}.", fileNames);
        return fileNames;
    }
    
    public async Task<byte[]> GetFileBytesFromChatAsync(long chatId, string fileName)
    {
        logger.Log(LogLevel.Trace, "Begin getting file with name = \"{fileName}\" " +
                                   "from chat with id = {chatId}.", fileName, chatId);

        var chat = await chatRepo.GetByIdAsNoTrackingAsync(chatId);
        var fullFilePath = Path.Combine(options.Value.ContentRootPath, "data\\chats", chat.DirectoryName, fileName);
        if (!Path.Exists(fullFilePath))
        {
            logger.Log(LogLevel.Debug,
                "File with name = \"{fileName}\", from chat with id = {chatId} not found. Returning empty byte array.",
                fileName, chatId);
            return Array.Empty<byte>();
        }
        var fileBytes = await File.ReadAllBytesAsync(fullFilePath);
        
        logger.Log(LogLevel.Debug, "Successfully got file with name = \"{fileName}\" " +
                                   "from chat with id = {chatId}.", fileName, chatId);
        return fileBytes;
    }
    
    public async Task<string> AddFileToMessageAsync(long messageId, IFormFile file)
    {
        logger.Log(LogLevel.Trace, "Begin uploading file with name = \"{fileName}\" " +
                                   "to message with id = {messageId}.", file.Name, messageId);

        var dbMessage = await messageRepo.GetByIdAsNoTrackingAsync(messageId);
        if (dbMessage.FileName is not "")
        {
            logger.Log(LogLevel.Debug, 
                "Message with id = {messageId}, already has a file. Returning empty string.",
                messageId);
            return "";
        }
        
        var chatRoot = Path.Combine(options.Value.ContentRootPath, "data\\chats", dbMessage.Chat.DirectoryName);
        if (!Directory.Exists(chatRoot))
        {
            Directory.CreateDirectory(chatRoot);
            logger.Log(LogLevel.Trace,
                "Directory for chat with id {chatId} was not found. Created directory with name {directoryName}.",
                dbMessage.Chat.Id, dbMessage.Chat.DirectoryName);
        }
        var fullFilePath = Path.Combine(chatRoot, file.FileName);
        
        await using var stream = File.Create(fullFilePath);
        await file.CopyToAsync(stream);
        logger.Log(LogLevel.Trace, "Successfully physically created file with name = \"{fileName}\" " +
                                   "to message with id = {messageId}.", file.Name, messageId);

        dbMessage.FileName = file.FileName;
        await messageRepo.UpdateAsync(dbMessage);
        await messageRepo.SaveChangesAsync();
        logger.Log(LogLevel.Trace, "Successfully added file with name = \"{fileName}\" " +
                                   "to message with id = {messageId} to database.", file.Name, messageId);
        
        logger.Log(LogLevel.Debug, "Successfully uploaded file with name = \"{fileName}\" " +
                                   "to message with id = {messageId}.", file.Name, messageId);
        return file.FileName;
    }

    public async Task<string> DeleteFileFromChatAsync(long chatId, string fileName)
    {
        logger.Log(LogLevel.Trace, "Begin deleting file with name = \"{fileName}\" " +
                                   "from chat with id = {messageId}.", fileName, chatId);

        var dbChat = await chatRepo.GetByIdAsNoTrackingAsync(chatId);
        var fullFilePath = Path.Combine(options.Value.ContentRootPath, "data\\chats", dbChat.DirectoryName, fileName);
        if (!Path.Exists(fullFilePath))
            return fileName;
        
        // если строчка с проверкой пути отработала (89) то файл точно существует => сообщение точно существует
        var dbMessage = dbChat.Messages.First(m => m.FileName == fileName);
        dbMessage.FileName = "";
        await messageRepo.UpdateAsync(dbMessage);
        await messageRepo.SaveChangesAsync();
        logger.Log(LogLevel.Trace, "Successfully deleted file from database with name = \"{fileName}\" " +
                                   "from message = {@message}.", fileName, dbMessage);
        
        File.Delete(fullFilePath);
        logger.Log(LogLevel.Trace, "Successfully physically deleted file with name = \"{fileName}\" " +
                                   "from message = {@message}.", fileName, dbMessage);
        
        logger.Log(LogLevel.Debug, "Successfully deleted file with name = \"{fileName}\" " +
                                   "from message = {messageId}.", fileName, chatId);
        return fileName;
    }
}