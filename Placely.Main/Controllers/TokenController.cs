using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using IAuthorizationService = Placely.Data.Abstractions.Services.IAuthorizationService;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class TokenController(IAuthorizationService service) : ControllerBase
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