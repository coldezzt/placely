namespace BL.Entities;

public class Landlord
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public string ContactAddress { get; set; }

    public List<Property> Properties { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Contract> Contracts { get; set; }
    public List<Chat> Chats { get; set; }
}