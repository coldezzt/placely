using System.Security.Claims;
using AutoMapper;
using FluentValidation;
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
[Route("api/[controller]")]
public class AuthorizationController(
    IAuthorizationService service,
    IMapper mapper,
    IValidator<AuthorizationDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Авторизует пользователя", 
        description:  "**Если** на аккаунте подключена двухфакторная аутентификация необходимо " +
                      "передавать и одноразовый ключ. **Иначе** поле игнорируется.")]
    [SwaggerResponse(
        statusCode: 200, 
        description: "Cгенерированные токены для текущего пользователя.", 
        type: typeof(TokenDto), 
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 400, 
        description: "Неверные аутентификационные данные.", 
        type: typeof(string),
        contentTypes: "text/plain")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationError>),
        contentTypes: "application/json")]
    [HttpPost]
    public async Task<IActionResult> Authorize(
        [FromBody] 
        [SwaggerRequestBody(
            description: "Данные для авторизации", 
            Required = true)] 
        AuthorizationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
    
        var authResult = await service.AuthorizeAsync(dto);
    
        if (!authResult.IsSuccess)
            return BadRequest(authResult.Error);

        return Ok(authResult.TokenDto);
    }

    [SwaggerOperation(
        summary: "Авторизует пользователя используя Google OAuth",
        description: "Ничего не возвращает и не принимает, всегда перенаправляет пользователя на Google OAuth.")]
    [SwaggerResponse(
        statusCode: 302,
        description: "Перенаправление на Google OAuth.")]
    [HttpGet("google")]
    public Task<IActionResult> GoogleAuthorize()
    {
        var authenticationProperties = new AuthenticationProperties {RedirectUri = Url.Action("GoogleCallback")};
        return Task.FromResult<IActionResult>(Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme));
    }
    
    [SwaggerOperation(
        summary: "Обратный вызов для авторизации с использованием Google OAuth",
        description: """
                     Используется самим Google OAuth автоматически.
                     
                     Если обращается **уже** авторизованный пользователь возвращает его токены авторизации 
                     (обновляя refresh-token).
                     """)]
    [SwaggerResponse(
        statusCode: 200,
        description: "Cгенерированные токены для текущего пользователя.",
        type: typeof(TokenDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 400,
        description: """
                     Неизвестная ошибка при аутентификации пользователя. 
                     
                     Возвращает пустую строку.
                     
                     Такое может случиться **только** если пользователь вручную менял Cookie, 
                     которые предоставляет Google **или** изменилась процедура авторизации через Google OAuth.
                     """,
        type: typeof(string),
        contentTypes: "text/plain")]
    [HttpGet("google/callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var authResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!authResult.Succeeded)
            return BadRequest("");

        var email = authResult.Principal.FindFirstValue(ClaimTypes.Email)!;

        var tokens = await service.AuthorizeUserFromExternalService(email, authResult.Principal.Claims);
        return Ok(tokens);
    }

    [SwaggerOperation(
        summary: "Применяет двухфакторную аутентификацию (2FA) к аккаунту с использованием TOTP от Google Authenticator",
        description: """
                     1) **Если** обращается авторизованный пользователь: 
                        - **Если** у пользователя не добавлена 2FA, то добавляет 2FA для этого аккаунта и возвращает ключи 
                        для настройки на стороне клиента - ключ для ручного ввода, и QR-код в виде строки.
                        - **Иначе** достаёт данные о 2FA из базы данных.
                     2) **Иначе**:
                        - Возвращает код 401 - Unauthorized. 
                     """)]
    [SwaggerResponse(
        statusCode: 200,
        description: "2FA успешно добавлена. Содержит токен для ручного ввода, и QR-код в виде строки.",
        type: typeof(TwoFactorAuthenticationModel),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
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
}