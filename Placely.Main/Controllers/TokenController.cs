using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using IAuthorizationService = Placely.Data.Abstractions.Services.IAuthorizationService;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class TokenController(
    IAuthorizationService service) : ControllerBase
{
    [SwaggerOperation(
        summary: "Обновляет токены доступа пользователя",
        description: "Для обновления необходимы старые токены.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Обновлённые токены пользователя. ",
        type: typeof(TokenDto),
        contentTypes: "application/json")]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
        [FromBody] 
        [SwaggerRequestBody(
            description: "Старые токены доступа.",
            Required = true)]
        TokenDto tokenDto)
    {
        var result = await service.RefreshTokenAsync(tokenDto);
        return Ok(result);
    }
}