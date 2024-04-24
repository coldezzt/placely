using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Models;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class TokenController(
    IAuthorizationService service) : ControllerBase
{
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var result = await service.RefreshTokenAsync(tokenDto);
        return Ok(result);
    }
}