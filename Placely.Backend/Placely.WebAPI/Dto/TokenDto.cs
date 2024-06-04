using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class TokenDto
{
    [DefaultValue("[should_be_sended_automatically]")]
    public string AccessToken { get; set; }

    [DefaultValue("[should_be_sended_automatically]")]
    public string RefreshToken { get; set; }
}