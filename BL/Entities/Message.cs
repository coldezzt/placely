namespace BL.Entities;

public class Message
{
    public long Id { get; set; }
    
    public long ChatId { get; set; }
    public Chat Chat { get; set; }
        
    public long AuthorId { get; set; }
    public Tenant Author { get; set; }
    
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string FilePath { get; set; }
}