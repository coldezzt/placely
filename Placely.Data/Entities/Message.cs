using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Message : IEntity
{
    public long Id { get; set; }
    
    public long ChatId { get; set; }
    public virtual Chat Chat { get; set; }
        
    public long AuthorId { get; set; }
    public virtual Tenant Author { get; set; }
    
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string? FilePath { get; set; }
}