using Placely.Domain.Abstractions.Entities;
using Placely.Domain.Enums;

namespace Placely.Domain.Entities;

public class Reservation : IEntity
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }

    public long LandlordId { get; set; }
    public virtual Landlord Landlord { get; set; }

    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }

    public ReservationStatusType? StatusType { get; set; }
    public string? DeclineReason { get; set; }
    public DateTime CreationDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime EntryDate { get; set; }
    public byte GuestsAmount { get; set; }
}