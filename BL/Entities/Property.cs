namespace BL.Entities;

public class Property
{
    public long Id { get; set; }
    
    public long OwnerId { get; set; }
    public Landlord Owner { get; set; }
    
    public byte TypeId { get; set; }
    public PropertyType Type { get; set; }

    public long PriceListId { get; set; }
    public PriceList PriceList { get; set; }
    
    public string Address { get; set; }
    public string Description { get; set; }
    
    public List<PropertyOption> Options { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Contract> Contracts { get; set; }
    public List<Tenant> InFavourites { get; set; }
}