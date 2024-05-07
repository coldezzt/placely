using System.ComponentModel;
using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ChatController(IChatService chatService, IMapper mapper) : ControllerBase
{
    [SwaggerOperation("Получает список всех чатов для текущего пользователя",
        "Используется для получения всех чатов (без истории сообщений) пользователя, когда он перешёл на страницу с сообщениями.")]
    [SwaggerResponse(200, "Список информации по всем чатам пользователя.", typeof(List<ChatDto>), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpGet("my/list")]
    public async Task<IActionResult> GetList()
    {
        var id = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var result = await chatService.GetListByUserIdAsync(id);
        var dtoList = result.Select(mapper.Map<ChatDto>);
        return Ok(dtoList);
    }

    [SwaggerOperation("Возвращает чат по его идентификатору",
        "Может быть использовано, когда вам нужно часто проверять" +
        " только несколько определённых чатов, а не все сразу.")]
    [SwaggerResponse(200, "Информация по выбранному чату.", typeof(ChatDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Пользователь попытался получить чат, участником, которого он не является.")]
    [HttpGet("{chatId:long}")]
    public async Task<IActionResult> Get(
        [DefaultValue(1)] [SwaggerParameter("Идентификатор чата.", Required = true)] long chatId)
    {
        var id = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var chat = await chatService.GetByIdAsync(chatId);
        if (id != chat.FirstUserId && id != chat.SecondUserId) return Forbid();
        var response = mapper.Map<ChatDto>(chat);
        return Ok(response);
    }

    [SwaggerOperation("Создаёт чат между пользователями",
        "Запрещено создавать чат с самим собой и нельзя создать чат " +
        "между двумя пользователями если он уже существует.")]
    [SwaggerResponse(200, "Информация про созданный чат.", typeof(ChatDto),
        "application/json")]
    [SwaggerResponse(409, "Попытка создать чат с самим собой или с уже существующим аккаунтом.")]
    [HttpPost("my")]
    public async Task<IActionResult> Create(
        [DefaultValue(1)]
        [FromQuery]
        [SwaggerParameter("Идентификатор собеседника.", Required = true)]
        long otherUserId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var chat = await chatService.CreateBetweenAsync(currentUserId, otherUserId);
        var response = mapper.Map<ChatDto>(chat);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет чат по его идентификатору",
        "Нельзя удалить чат, участником которого пользователь не является.")]
    [SwaggerResponse(200, "Чат успешно удалён.", typeof(ChatDto), "application/json")]
    [SwaggerResponse(403, "Попытка удалить чат, участником которого пользователь не является.")]
    [HttpDelete("my/{chatId:long}")]
    public async Task<IActionResult> Delete(
        [DefaultValue(1)] [SwaggerParameter("Идентификатор чата.", Required = true)] long chatId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbChat = await chatService.GetByIdAsync(chatId);
        if (currentUserId != dbChat.FirstUserId && currentUserId != dbChat.SecondUserId) return Forbid();
        var chat = await chatService.DeleteByIdAsync(chatId);
        var response = mapper.Map<ChatDto>(chat);
        return Ok(response);
    }
}