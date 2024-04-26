using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Dtos;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;
using IAuthorizationService = Placely.Data.Abstractions.Services.IAuthorizationService;

namespace Placely.Main.Controllers;

[ApiController]
[Route("api")]
public class AuthorizeController(
    IAuthorizationService service,
    IValidator<AuthorizationDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Авторизует пользователя", 
        description:  """
                      Используется для авторизации пользователя.
                      
                      **Если** на аккаунте подключена двухфакторная аутентификация необходимо передавать и одноразовый ключ.
                      **Иначе** поле игнорируется.
                      """ )]
    [SwaggerResponse(
        statusCode: 200, 
        description: "Cгенерированные токены для текущего пользователя", 
        type: typeof(TokenDto), 
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 400, 
        description: "Неверные аутентификационные данные", 
        type: typeof(string),
        contentTypes: "text/plain")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Неверный формат входных данных",
        type: typeof(List<ValidationFailure>),
        contentTypes: "application/json")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Authorize(
        [FromBody, SwaggerRequestBody(Description = "Объект для авторизации", Required = true)] AuthorizationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);
    
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
            return BadRequest("");

        var email = authResult.Principal.FindFirstValue(ClaimTypes.Email)!;

        var token = await service.AuthorizeUserFromExternalService(email, authResult.Principal.Claims);
        return Ok(token);
    }

    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
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