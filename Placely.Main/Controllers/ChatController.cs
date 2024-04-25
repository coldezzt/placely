using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class ChatController(
    IChatService service,
    IMapper mapper) : ControllerBase
{
    [HttpGet("my/list")]
    public async Task<IActionResult> GetList()
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        var result = await service.GetListByUserIdAsync(id);
        var dtos = result.Select(mapper.Map<ChatDto>);
        return Ok(dtos);
    }

    [HttpGet("{chatId}")]
    public async Task<IActionResult> Get(long chatId)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        var chat = await service.GetByIdAsync(chatId);
        if (id != chat.FirstUserId && id != chat.SecondUserId)
            return Forbid();
        
        return Ok(chat);
    }
    
    [HttpPost("my")]
    public async Task<IActionResult> Create([FromBody] ChatDto dto)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        // Нельзя создать чат с самим собой
        if (dto.FirstUserId == dto.SecondUserId)
            return Conflict();

        dto.FirstUserId = id;

        var chat = mapper.Map<Chat>(dto);
        var result = await service.CreateAsync(chat);
        return Created(result.DirectoryPath, result);
    }

    [HttpDelete("my/{chatId}")]
    public async Task<IActionResult> Delete(long chatId)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        var dbChat = await service.GetByIdAsync(chatId);
        if (id != dbChat.FirstUserId && id != dbChat.SecondUserId)
            return Forbid();

        var chat = await service.DeleteByIdAsync(chatId);
        return Ok(chat);
    }
}