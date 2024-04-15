using Placely.Data.Abstractions;
using Placely.Data.Models;

namespace Placely.Data.Entities;

public class Property : IEntity
{
    public long Id { get; set; }
    
    public long OwnerId { get; set; }
    public Landlord Owner { get; set; }
    
    public PropertyType Type { get; set; }

    public long PriceListId { get; set; }
    public PriceList PriceList { get; set; }
    
    public string Address { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public double Rating { get; set; }
    
    public List<Review> Reviews { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Contract> Contracts { get; set; }
    public List<Tenant> InFavourites { get; set; }
}