using Placely.Data.Models;

namespace Placely.Data.Dtos;

public class ReservationDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long LandlordId { get; set; }
    public long PropertyId { get; set; }
    
    public string? ReservationStatus { get; set; }
    public string? DeclineReason { get; set; }
    public byte GuestsAmount { get; set; }
    public DateTime CreationDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime EntryDate { get; set; }
}