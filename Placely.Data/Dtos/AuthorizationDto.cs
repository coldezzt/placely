using System.ComponentModel;

namespace Placely.Data.Dtos;

public class AuthorizationDto
{
    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    [DefaultValue("user@example.com")]
    public string Email { get; set; } = "user@example.com";
    public string Password { get; set; }
    public string? TwoFactorKey { get; set; }
}