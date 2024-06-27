using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Notification : IEntity
{
    public long Id { get; set; }
    
    public long ReceiverId { get; set; }
    public virtual User Receiver { get; set; }
    
    public string Title { get; set; }
    public string? Content { get; set; }
    public DateOnly Date { get; set; }
    public bool IsDeleted { get; set; }
}