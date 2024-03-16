namespace BL.Entities;

public class Reservation
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }

    public long LandlordId { get; set; }
    public Landlord Landlord { get; set; }

    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public byte ReservationStatusId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }

    public TimeSpan Duration { get; set; }
    public DateTime EntryDate { get; set; }
    public byte GuestsAmount { get; set; }
}