using System.ComponentModel;

namespace Placely.Data.Dtos;

public class MessageDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [DefaultValue(1)]
    public long ChatId { get; set; }
    
    [DefaultValue(1)]
    public long AuthorId { get; set; }
    
    [DefaultValue("Привет, мир!")]
    public string Content { get; set; }
    public DateTime Date { get; set; }

    [DefaultValue("filename.txt")]
    public string? FileName { get; set; }
}