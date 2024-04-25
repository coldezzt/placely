namespace Placely.Data.Models;

public class AuthorizationResult
{
    public TokenDto TokenDto { get; set; }
    public bool IsSuccess { get; set; }
    public string Error { get; set; }
}