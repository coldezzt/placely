namespace Placely.Application.Common.Models;

public class RefreshTokenModel
{
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
}