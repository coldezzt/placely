using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Review : IEntity
{
    public long Id { get; set; }
    
    public long AuthorId { get; set; }
    public virtual Tenant Author { get; set; }

    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }
    
    public double Rating { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
}