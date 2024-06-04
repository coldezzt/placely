using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Models;
using Placely.Domain.Abstractions.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Route("api/[controller]")]
public class TokenController(
    IAuthService service,
    IMapper mapper
    ) : ControllerBase
{
    [SwaggerOperation("Обновляет токены доступа пользователя", "Для обновления необходимы старые токены.")]
    [SwaggerResponse(200, "Обновлённые токены пользователя. ", typeof(TokenDto), "application/json")]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
        [FromBody] [SwaggerRequestBody("Старые токены доступа.", Required = true)] TokenDto dto)
    {
        var tokenModel = mapper.Map<TokenModel>(dto);
        var result = await service.RefreshTokenAsync(tokenModel);
        return Ok(result);
    }
}