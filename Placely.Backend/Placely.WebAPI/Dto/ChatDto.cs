using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class ChatDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [DefaultValue(6)]
    public long OtherUserId { get; set; }
}