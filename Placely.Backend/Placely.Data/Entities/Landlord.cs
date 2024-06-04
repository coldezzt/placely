using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Landlord : IEntity
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    
    public string ContactAddress { get; set; }

    public virtual List<Property> Properties { get; set; }
    public virtual List<Reservation> Reservations { get; set; }
    public virtual List<Contract> Contracts { get; set; }
    public virtual List<Chat> Chats { get; set; }
}