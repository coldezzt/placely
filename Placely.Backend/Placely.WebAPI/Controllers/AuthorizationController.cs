using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Infrastructure.Common.Models;
using Placely.Infrastructure.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController(
    IAuthService service, 
    IMapper mapper,
    IValidator<AuthorizationDto> validator) : ControllerBase
{
    [SwaggerOperation("Авторизует пользователя",
        "**Если** на аккаунте подключена двухфакторная аутентификация необходимо " +
        "передавать и одноразовый ключ. **Иначе** поле игнорируется.")]
    [SwaggerResponse(200, "Cгенерированные токены для текущего пользователя.", typeof(TokenDto), "application/json")]
    [SwaggerResponse(400, "Неверные аутентификационные данные.", typeof(string), "text/plain")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Authorize(
        [FromBody] [SwaggerRequestBody("Данные для авторизации", Required = true)] AuthorizationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var model = mapper.Map<AuthorizationModel>(dto);
        var authResult = await service.AuthorizeAsync(model);
        if (!authResult.IsSuccess) return BadRequest(authResult.Error);
        return Ok(authResult.TokenModel);
    }

    [SwaggerOperation("Авторизует пользователя используя Google OAuth",
        "Ничего не возвращает и не принимает, всегда перенаправляет пользователя на Google OAuth.")]
    [SwaggerResponse(302, "Перенаправление на Google OAuth.")]
    [HttpGet("google")]
    public Task<IActionResult> GoogleAuthorize()
    {
        var authenticationProperties = new AuthenticationProperties {RedirectUri = Url.Action("GoogleCallback")};
        return Task.FromResult<IActionResult>(Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme));
    }

    [SwaggerOperation("Обратный вызов для авторизации с использованием Google OAuth", """
        Используется самим Google OAuth автоматически.

        Если обращается **уже** авторизованный пользователь возвращает его токены авторизации
        (обновляя refresh-token).
        """)]
    [SwaggerResponse(200, "Cгенерированные токены для текущего пользователя.", typeof(TokenDto), "application/json")]
    [SwaggerResponse(400, """
                          Неизвестная ошибка при аутентификации пользователя.

                          Возвращает пустую строку.

                          Такое может случиться **только** если пользователь вручную менял Cookie,
                          которые предоставляет Google **или** изменилась процедура авторизации через Google OAuth.
                          """, typeof(string), "text/plain")]
    [HttpGet("google/callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var authResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!authResult.Succeeded) return BadRequest("");
        var email = authResult.Principal.FindFirstValue(ClaimTypes.Email)!;
        var tokens = await service.AuthorizeUserFromExternalService(email, authResult.Principal.Claims);
        return Ok(tokens);
    }

    [SwaggerOperation(
        "Применяет двухфакторную аутентификацию (2FA) к аккаунту с использованием TOTP от Google Authenticator", """
            1) **Если** обращается авторизованный пользователь:
               - **Если** у пользователя не добавлена 2FA, то добавляет 2FA для этого аккаунта и возвращает ключи
               для настройки на стороне клиента - ключ для ручного ввода, и QR-код в виде строки.
               - **Иначе** достаёт данные о 2FA из базы данных.
            2) **Иначе**:
               - Возвращает код 401 - Unauthorized.
            """)]
    [SwaggerResponse(200, "2FA успешно добавлена. Содержит токен для ручного ввода, и QR-код в виде строки.",
        typeof(TwoFactorAuthenticationModel), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [Authorize, HttpPost("google/2fa")]
    public async Task<IActionResult> GoogleTwoFactorCreation()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (email is null) return Unauthorized();
        var model = await service.ApplyGoogleTwoFactorAuthenticationAsync(email);
        return Ok(model);
    }
}