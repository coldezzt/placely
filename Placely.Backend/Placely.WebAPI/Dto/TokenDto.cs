using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи данных о токенах доступа.")]
public class TokenDto
{
    [SwaggerSchema("Токен доступа.")]
    [DefaultValue("[should_be_sended_automatically]")]
    public string AccessToken { get; set; }

    [SwaggerSchema("Токен для обновления токена доступа (refresh-токен).")]
    [DefaultValue("[should_be_sended_automatically]")]
    public string RefreshToken { get; set; }
}