using System.Globalization;
using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Models;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/chat/my/{chatId:long}/file")]
public class ChatFileController(
    IChatService chatService,
    IMessageService messageService) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetAssociatedFiles(long chatId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (currentUserId != dbChat.FirstUserId 
            && currentUserId != dbChat.SecondUserId)
            return Forbid();

        var paths = await messageService.GetFilesListAsync(chatId);
        return Ok(paths);
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadFile(
        [FromRoute] long chatId, 
        [FromQuery] long messageId, 
        [FromBody] IFormFile file)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId
            && dbChat.SecondUserId != currentUserId)
            return Forbid();
        
        var dbMessage = dbChat.Messages.FirstOrDefault(m => m.Id == messageId);
        if (dbMessage is null)
            return NotFound();
        
        var pathToFile = await messageService.UploadFileAsync(chatId, messageId, file);

        return Ok(pathToFile);
    }

    [HttpGet]
    public async Task<IActionResult> DownloadFile(
        [FromRoute] long chatId,
        [FromQuery] string filePath)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId
            && dbChat.SecondUserId != currentUserId)
            return Forbid();

        var file = await messageService.GetFileBytesAsync(filePath);
        return File(file, MediaTypeNames.Application.Octet, Path.GetFileName(filePath));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFile(
        [FromRoute] long chatId,
        [FromQuery] string filePath)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId
            && dbChat.SecondUserId != currentUserId)
            return Forbid();

        var deletedFilePath = await messageService.DeleteFileAsync(filePath);
        return deletedFilePath is "" ? UnprocessableEntity() : Ok(deletedFilePath);
    }
}