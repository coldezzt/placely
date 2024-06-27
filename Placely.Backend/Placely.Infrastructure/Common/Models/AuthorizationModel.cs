namespace Placely.Infrastructure.Common.Models;

public class AuthorizationModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? TwoFactorKey { get; set; }
}