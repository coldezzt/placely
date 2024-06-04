using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Models;

public class AuthorizationResult
{
    public TokenDto TokenDto { get; set; }
    public bool IsSuccess { get; set; }
    public string Error { get; set; }
}