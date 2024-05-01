using System.ComponentModel;

namespace Placely.Data.Dtos;

public class AuthorizationDto
{
    /// <summary>
    /// Электронная почта пользователя.
    /// </summary>
    [DefaultValue("user@example.com")]
    public string Email { get; set; } = "user@example.com";
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    [DefaultValue("8uperC00l+password!")]
    public string Password { get; set; }
    
    /// <summary>
    /// Двухфакторный одноразовый код. Проверяется ТОЛЬКО если на аккаунте подключена двухфакторная аутентификация.
    /// </summary>
    [DefaultValue("123456")]
    public string? TwoFactorKey { get; set; }
}