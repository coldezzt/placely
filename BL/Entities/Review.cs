namespace BL.Entities;

public class Review
{
    public long Id { get; set; }
    
    public long AuthorId { get; set; }
    public Tenant Author { get; set; }

    public long PropertyId { get; set; }
    public Property Property { get; set; }
    
    public long Rating { get; set; }
    public string Content { get; set; }
}