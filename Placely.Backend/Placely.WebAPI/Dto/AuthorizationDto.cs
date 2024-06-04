using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class AuthorizationDto
{
    [DefaultValue("user@example.com")]
    public string Email { get; set; } = "user@example.com";
    
    [DefaultValue("8uperC00l+password!")]
    public string Password { get; set; }
    
    [DefaultValue("123456")]
    public string? TwoFactorKey { get; set; }
}