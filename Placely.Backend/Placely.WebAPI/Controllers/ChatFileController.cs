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
public class ChatFileController(
        IChatService chatService, 
        IMessageService messageService
    ) : ControllerBase
{
    [SwaggerOperation("Получает все названия файлов выбранного чата",
        "Нельзя получить названия файлов из чужого чата.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Список название файлов.", typeof(List<string>),
        "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка получить список файлов из чужого чата.")]
    [HttpGet("list")]
    public async Task<IActionResult> GetAssociatedFiles( // GET api/chat/my/{chatId}/file/list
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
    [SwaggerResponse(StatusCodes.Status200OK, "Путь до загруженного файла.", typeof(string),
        "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка загрузить файл в чужой чат.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "Попытка загрузить файл в сообщение, у которого уже есть файл.")]
    [HttpPost]
    public async Task<IActionResult> UploadFile( // POST api/chat/my/{chatId}/file?messageId={messageId}?file={file}
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
    [SwaggerResponse(StatusCodes.Status200OK, "Файл.", typeof(FileContentResult),
        "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка загрузить файл из чужого чата.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Файл для скачивания не был найден.")]
    [HttpGet]
    public async Task<IActionResult> DownloadFile( // GET api/chat/my/{chatId}/file?fileName={fileName}
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
    [SwaggerResponse(StatusCodes.Status200OK, "Путь до удалённого файла. Возвращается даже если была попытка удалить несуществующий файл.",
        typeof(string), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка удалить файл из чужого чата.")]
    [HttpDelete]
    public async Task<IActionResult> DeleteFile( // DELETE api/chat/my/{chatId}/file?fileName={fileName}
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