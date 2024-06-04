using System.ComponentModel;

namespace Placely.Data.Dtos;

public class ReviewDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [DefaultValue(1)]
    public long AuthorId { get; set; }

    [DefaultValue(1)]
    public long PropertyId { get; set; }
    
    [DefaultValue(4.3)]
    public double Rating { get; set; }
    public DateTime Date { get; set; }
    
    [DefaultValue("Очень крутой дом! Нам понравилось!")]
    public string Content { get; set; }
}