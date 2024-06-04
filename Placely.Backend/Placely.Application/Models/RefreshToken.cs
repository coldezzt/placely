namespace Placely.Application.Models;

public class RefreshToken
{
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
}