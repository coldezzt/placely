using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для регистрации пользователя.")]
public class RegistrationDto
{
    [SwaggerSchema("ФИО пользователя.")]
    [DefaultValue("Иванов Иван Иванович")]
    public string Name { get; set; }
    
    [SwaggerSchema("Мобильный телефон пользователя.")]
    [DefaultValue("89876543210")]
    public string PhoneNumber { get; set; }
    
    [SwaggerSchema("Электронная почта пользователя.")]
    [DefaultValue("user@example.com")]
    public string Email { get; set; }
    
    [SwaggerSchema("Пароль пользователя.")]
    [DefaultValue("8uperC00l+password!")]
    public string Password { get; set; }
}