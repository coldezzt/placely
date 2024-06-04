using Placely.Domain.Abstractions.Entities;

namespace Placely.Domain.Entities;

public class Contract : IEntity
{
    public long Id { get; set; }
    public long ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public string? FinalizedDocxFileName { get; set; }
    public string? FinalizedPdfFileName { get; set; }
}