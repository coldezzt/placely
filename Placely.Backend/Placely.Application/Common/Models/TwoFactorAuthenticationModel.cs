using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Application.Common.Models;

[SwaggerSchema("Объект для передачи данных о двухфакторной аутентификации пользователя.")]
public class TwoFactorAuthenticationModel
{
    [SwaggerSchema("Двухфакторный ключ для ручного ввода.")]
    public required string ManualEntryKey { get; set; }

    [SwaggerSchema("Ключ в виде QR кода.")]
    public string? QrImageUrl { get; set; }
}