using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class SensitiveUserDto
{
    [DefaultValue("Иванов Иван Иванович")]
    public string Name { get; set; }

    [DefaultValue("89876543210")]
    public string PhoneNumber { get; set; }

    [DefaultValue("user@example.com")]
    public string Email { get; set; }

    [DefaultValue("8uperC00l+password!")]
    public string OldPassword { get; set; }
    
    [DefaultValue("4not6er8uperC00l+password!")]
    public string? NewPassword { get; set; }
}