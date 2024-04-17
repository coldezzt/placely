using Placely.Data.Entities;

namespace Placely.Data.Dtos;

public class PropertyDto
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PublicationDate { get; set; }
    public double Rating { get; set; }
    public PriceList PriceList { get; set; }
}