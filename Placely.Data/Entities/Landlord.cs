using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Landlord : IEntity
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