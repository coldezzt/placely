using System.ComponentModel;
using System.Globalization;
using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/chat/my/{chatId:long}/file")]
public class ChatFileController(IChatService chatService, IMessageService messageService) : ControllerBase
{
    [SwaggerOperation("Получает все файлы выбранного чата",
        "Нельзя получить файлы из чужого чата.")]
    [SwaggerResponse(200, "Список путей до файлов.", typeof(List<string>),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить файлы из чужого чата.")]
    [HttpGet("list")]
    public async Task<IActionResult> GetAssociatedFiles(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (currentUserId != dbChat.FirstUserId && currentUserId != dbChat.SecondUserId) return Forbid();
        var paths = await messageService.GetFilesListAsync(chatId);
        return Ok(paths);
    }

    [SwaggerOperation("Загружает файл в чат", "Нельзя загрузить файл в чужой чат.")]
    [SwaggerResponse(200, "Путь до загруженного файла.", typeof(string),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл в чужой чат.")]
    [HttpPost]
    public async Task<IActionResult> UploadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId,
        [DefaultValue(1)] [FromQuery] [SwaggerParameter("Идентификатор сообщения.", Required = true)]
        long messageId, [FromBody] [SwaggerParameter("Файл.", Required = true)] IFormFile file)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId && dbChat.SecondUserId != currentUserId) return Forbid();
        var dbMessage = dbChat.Messages.FirstOrDefault(m => m.Id == messageId);
        if (dbMessage is null) return NotFound();
        var pathToFile = await messageService.UploadFileAsync(chatId, messageId, file);
        return Ok(pathToFile);
    }

    [SwaggerOperation("Скачивает файл из чата", "Нельзя скачать файл из чужого чата.")]
    [SwaggerResponse(200, "Файл.", typeof(FileContentResult),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл из чужого чата.")]
    [HttpGet]
    public async Task<IActionResult> DownloadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long chatId,
        [DefaultValue("/new.txt")] [FromQuery] [SwaggerParameter("Путь к файлу для скачивания.", Required = true)]
        string filePath)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId && dbChat.SecondUserId != currentUserId) return Forbid();
        var file = await messageService.GetFileBytesAsync(filePath);
        return File(file, MediaTypeNames.Application.Octet, Path.GetFileName(filePath));
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
        [DefaultValue("/new.txt")] [FromQuery] [SwaggerParameter("Путь к файлу для скачивания.", Required = true)]
        string filePath)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != currentUserId && dbChat.SecondUserId != currentUserId) return Forbid();
        var deletedFilePath = await messageService.DeleteFileAsync(filePath);
        return Ok(deletedFilePath);
    }
}