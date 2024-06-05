using System.ComponentModel;
using System.Globalization;
using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Authorize]
[Route("api/chat/my/{chatId:long}/file")]
public class ChatFileController(IChatService chatService, IMessageService messageService) : ControllerBase
{
    [SwaggerOperation("Получает все названия файлов выбранного чата",
        "Нельзя получить названия файлов из чужого чата.")]
    [SwaggerResponse(200, "Список название файлов.", typeof(List<string>),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить список файлов из чужого чата.")]
    [HttpGet("list")]
    public async Task<IActionResult> GetAssociatedFiles(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var names = await messageService.GetListFileNamesAsync(chatId);
        return Ok(names);
    }

    [SwaggerOperation("Загружает файл в чат", "Нельзя загрузить файл в чужой чат.")]
    [SwaggerResponse(200, "Путь до загруженного файла.", typeof(string),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл в чужой чат.")]
    [SwaggerResponse(409, "Попытка загрузить файл в сообщение, у которого уже есть файл.")]
    [HttpPost]
    public async Task<IActionResult> UploadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId,
        [DefaultValue(1)] [FromQuery] [SwaggerParameter("Идентификатор сообщения.", Required = true)]
        long messageId, [FromQuery] [SwaggerParameter("Файл.", Required = true)] IFormFile file)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var dbMessage = dbChat.Messages.FirstOrDefault(m => m.Id == messageId);
        if (dbMessage is null) 
            return NotFound();
        
        var fileName = await messageService.AddFileToMessageAsync(messageId, file);
        return fileName is "" 
            ? Conflict() 
            : Ok(fileName);
    }

    [SwaggerOperation("Скачивает файл из чата", "Нельзя скачать файл из чужого чата.")]
    [SwaggerResponse(200, "Файл.", typeof(FileContentResult),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл из чужого чата.")]
    [SwaggerResponse(404, "Файл для скачивания не был найден.")]
    [HttpGet]
    public async Task<IActionResult> DownloadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId,
        [DefaultValue("new.txt")] [FromQuery] [SwaggerParameter("Название файла для скачивания.", Required = true)]
        string fileName)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var file = await messageService.GetFileBytesFromChatAsync(dbChat.Id, fileName);
        return file.Length == 0 
            ? NotFound() 
            : File(file, MediaTypeNames.Application.Octet, fileName);
    }

    [SwaggerOperation("Удаляет файл из чата", "Нельзя удалить файл из чужого чата.")]
    [SwaggerResponse(200, "Путь до удалённого файла. Возвращается даже если была попытка удалить несуществующий файл.",
        typeof(string), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка удалить файл из чужого чата.")]
    [HttpDelete]
    public async Task<IActionResult> DeleteFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId,
        [DefaultValue("new.txt")] [FromQuery] [SwaggerParameter("Название файла для удаления.", Required = true)]
        string fileName)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var deletedFileName = await messageService.DeleteFileFromChatAsync(dbChat.Id, fileName);
        return Ok(deletedFileName);
    }
}