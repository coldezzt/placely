using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Notification : IEntity
{
    public long Id { get; set; }
    
    public long ReceiverId { get; set; }
    public Tenant Receiver { get; set; }
    
    public string Title { get; set; }
    public string Content { get; set; }
    public DateOnly Date { get; set; }
    public bool IsDeleted { get; set; }
}