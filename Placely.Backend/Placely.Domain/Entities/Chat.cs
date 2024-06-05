using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Chat : IEntity
{
    public long Id { get; set; }
    
    public string DirectoryName { get; set; }
    public virtual List<Message> Messages { get; set; }
    public virtual List<User> Participants { get; set; }
}