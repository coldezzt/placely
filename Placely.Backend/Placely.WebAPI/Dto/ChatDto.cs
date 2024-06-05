using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class ChatDto
{
    [DefaultValue(1)]
    public long Id { get; set; }

    public List<long> Participants { get; set; } = new();
}