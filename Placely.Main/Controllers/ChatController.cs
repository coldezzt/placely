using System.Globalization;
using System.Net.Mime;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ChatController(
    IChatService chatService,
    IMessageService messageService,
    IMapper mapper) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает список всех чатов для текущего пользователя",
        description: "Используется для получения всех чатов (без истории сообщений) пользователя, когда он перешёл на страницу с сообщениями.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Список информации по всем чатам пользователя.",
        type: typeof(List<ChatDto>),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [HttpGet("my/list")]
    public async Task<IActionResult> GetList()
    {
        var id = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var result = await chatService.GetListByUserIdAsync(id);
        var dtoList = result.Select(mapper.Map<ChatDto>);
        return Ok(dtoList);
    }

    [SwaggerOperation(
        summary: "Возвращает чат по его идентификатору",
        description: "Может быть использовано, когда вам нужно часто проверять" +
                     "только несколько определённых чатов, а не все сразу.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по выбранному чату.",
        type: typeof(ChatDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Пользователь попытался получить чат, участником, которого он не является.")]
    [HttpGet("{chatId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter(description: "Идентификатор чата.", Required = true)] long chatId)
    {
        var id = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var chat = await chatService.GetByIdAsync(chatId);
        if (id != chat.FirstUserId && id != chat.SecondUserId)
            return Forbid();
        
        return Ok(chat);
    }

    [SwaggerOperation(
        summary: "Создаёт чат между пользователями",
        description: "Запрещено создавать чат с самим собой и нельзя создать чат " +
                     "между двумя пользователями если он уже существует.")]
    [SwaggerResponse(
        statusCode: 201,
        description: "Информация про созданный чат и путь до директории чата.",
        type: typeof(ChatDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 409,
        description: "Попытка создать чат с самим собой или с уже существующим аккаунтом.")]
    [HttpPost("my")]
    public async Task<IActionResult> Create(
        [FromQuery] long otherUserId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);
        
        var result = await chatService.CreateBetweenAsync(currentUserId, otherUserId);
        return Created(result.DirectoryPath, result);
    }

    [SwaggerOperation(
        summary: "Удаляет чат по его идентификатору",
        description: "Нельзя удалить чат, участником которого пользователь не является.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Чат успешно удалён.",
        type: typeof(ChatDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка удалить чат, участником которого пользователь не является.")]
    [HttpDelete("my/{chatId:long}")]
    public async Task<IActionResult> Delete(
        [SwaggerParameter(description: "Идентификатор чата.", Required = true)] long chatId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var dbChat = await chatService.GetByIdAsync(chatId);
        if (currentUserId != dbChat.FirstUserId 
            && currentUserId != dbChat.SecondUserId)
            return Forbid();

        var chat = await chatService.DeleteByIdAsync(chatId);
        return Ok(chat);
    }
}