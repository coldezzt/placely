using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для авторизации пользователя.")]
public class AuthorizationDto
{
    [SwaggerSchema("Электронная почта пользователя")]
    [DefaultValue("user@example.com")]
    public string Email { get; set; }
    
    [SwaggerSchema("Пароль пользователя")]
    [DefaultValue("8uperC00l+password!")]
    public string Password { get; set; }
    
    [SwaggerSchema("Двух-факторный ключ авторизации")]
    [DefaultValue("123456")]
    public string? TwoFactorKey { get; set; }
}