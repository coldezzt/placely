namespace Placely.Data.Dtos;

public class ReviewDto
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public long PropertyId { get; set; }
    public double Rating { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
}