using Placely.Domain.Common.Enums;
using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class Reservation : IEntity
{
    public long Id { get; set; }
    
    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }
    
    public long? ContractId { get; set; }
    public virtual Contract? Contract { get; set; }

    public ReservationStatus? Status { get; set; }
    public string? DeclineReason { get; set; }
    
    public DateTime CreationDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime EntryDate { get; set; }
    public byte GuestsAmount { get; set; }
    public decimal? PaymentAmount { get; set; }
    public string? PaymentFrequency { get; set; }
    
    public virtual List<User> Participants { get; set; }
}