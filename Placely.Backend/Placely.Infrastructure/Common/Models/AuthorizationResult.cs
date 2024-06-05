namespace Placely.Infrastructure.Common.Models;

public class AuthorizationResult
{
    public TokenModel TokenModel { get; set; }
    public bool IsSuccess { get; set; }
    public string Error { get; set; }
}