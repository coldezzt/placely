using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Chat : IEntity
{
    public long Id { get; set; }
    
    public long FirstUserId { get; set; }
    public virtual Tenant FirstUser { get; set; }
    
    public long SecondUserId { get; set; }
    public virtual Landlord SecondUser { get; set; }
    
    public string DirectoryPath { get; set; }
    
    public virtual List<Message> Messages { get; set; }
}