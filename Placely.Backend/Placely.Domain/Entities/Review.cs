using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Review : IEntity
{
    public long Id { get; set; }
    
    public long AuthorId { get; set; }
    public virtual User Author { get; set; }

    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }
    
    public double Rating { get; set; }
    public required DateTime Date { get; set; }
    public string? Content { get; set; }
}