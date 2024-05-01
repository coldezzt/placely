using System.ComponentModel;

namespace Placely.Data.Dtos;

public class ChatDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [DefaultValue(6)]
    public long OtherUserId { get; set; }
 
    [DefaultValue("")]
    public string DirectoryPath { get; set; }
}