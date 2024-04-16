using Placely.Data.Abstractions;
using Placely.Data.Models;

namespace Placely.Data.Entities;

public class Property : IEntity
{
    public long Id { get; set; }
    
    public long OwnerId { get; set; }
    public virtual Landlord Owner { get; set; }
    
    public PropertyType Type { get; set; }

    public long PriceListId { get; set; }
    public virtual PriceList PriceList { get; set; }
    
    public string Address { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public double Rating { get; set; }
    
    public virtual List<Review> Reviews { get; set; }
    public virtual List<Reservation> Reservations { get; set; }
    public virtual List<Contract> Contracts { get; set; }
    public virtual List<Tenant> InFavourites { get; set; }
}