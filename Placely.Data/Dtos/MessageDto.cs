namespace Placely.Data.Dtos;

public class MessageDto
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public long AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string? FilePath { get; set; }
}