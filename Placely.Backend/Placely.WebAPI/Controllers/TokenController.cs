using Microsoft.AspNetCore.Mvc;
using Placely.WebAPI.Abstractions.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Route("api/[controller]")]
public class TokenController(IAuthService service) : ControllerBase
{
    [SwaggerOperation("Обновляет токены доступа пользователя", "Для обновления необходимы старые токены.")]
    [SwaggerResponse(200, "Обновлённые токены пользователя. ", typeof(TokenDto), "application/json")]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
        [FromBody] [SwaggerRequestBody("Старые токены доступа.", Required = true)] TokenDto tokenDto)
    {
        var result = await service.RefreshTokenAsync(tokenDto);
        return Ok(result);
    }
}