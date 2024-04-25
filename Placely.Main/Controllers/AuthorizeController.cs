using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Dtos;
using IAuthorizationService = Placely.Data.Abstractions.Services.IAuthorizationService;

namespace Placely.Main.Controllers;

[Route("api")]
public class AuthorizeController(
    IAuthorizationService service,
    IValidator<AuthorizationDto> validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Authorize([FromBody] AuthorizationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
    
        var authResult = await service.AuthorizeAsync(dto);
    
        if (!authResult.IsSuccess)
            return BadRequest(authResult.Error);

        return Ok(authResult.TokenDto);
    }


    [HttpGet("google/authorize")]
    public async Task<IActionResult> GoogleAuthorize()
    {
        var authenticationProperties = new AuthenticationProperties {RedirectUri = Url.Action("GoogleCallback")};
        return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google/callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var authResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!authResult.Succeeded)
            return BadRequest();

        var email = authResult.Principal.FindFirstValue(ClaimTypes.Email)!;

        var token = await service.AuthorizeUserFromExternalService(email, authResult.Principal.Claims);
        return Ok(token);
    }

    [Authorize]
    [HttpPost("google/2fa")]
    public async Task<IActionResult> GoogleTwoFactorCreation()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (email is null)
            return Unauthorized();

        var model = await service.ApplyGoogleTwoFactorAuthenticationAsync(email);
        return Ok(model);
    }

    [Authorize]
    [HttpGet("google/2fa/keys")]
    public async Task<IActionResult> GoogleTwoFactorKeys()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var keys = await service.GetTwoFactorAuthenticationKeys(email);

        var html = $"<div><p>{keys.ManualEntryKey}</p><img src=\"{keys.QrImageUrl}\"></img></div>";
        return Content(html, "text/html");
    }
}