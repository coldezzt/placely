using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Message : IEntity
{
    public long Id { get; set; }
    
    public long ChatId { get; set; }
    public virtual Chat Chat { get; set; }
        
    public long AuthorId { get; set; }
    public virtual User Author { get; set; }
    
    public required string Content { get; set; }
    public DateTime Date { get; set; }
    public string FileName { get; set; } = "";
}