using Placely.Domain.Common.Enums;
using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Property : IEntity
{
    public long Id { get; set; }
    
    public long OwnerId { get; set; }
    public virtual User Owner { get; set; }
    
    public long PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; }
    
    public string Address { get; set; }
    public string Description { get; set; }
    public PropertyType Type { get; set; }
    public DateTime PublicationDate { get; set; }
    public double Rating { get; set; }
    
    public virtual List<Review> Reviews { get; set; }
    public virtual List<Reservation> Reservations { get; set; }
    public virtual List<User> Favourites { get; set; }
}