using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Reservation : IEntity
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }

    public long LandlordId { get; set; }
    public Landlord Landlord { get; set; }

    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public ReservationStatus ReservationStatus { get; set; }
    public string? DeclineReason { get; set; }
    public DateTime CreationDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime EntryDate { get; set; }
    public byte GuestsAmount { get; set; }
}