using System.ComponentModel;

namespace Placely.Data.Dtos;

public class ReservationDto
{
    [DefaultValue(1)]
    public long Id { get; set; }

    [DefaultValue(1)]
    public long TenantId { get; set; }
    
    [DefaultValue(1)]
    public long LandlordId { get; set; }
    
    [DefaultValue(1)]
    public long PropertyId { get; set; }
    
    public string ReservationStatus { get; set; }
    
    [DefaultValue("Сегодня ретроградный меркурий.")]
    public string? DeclineReason { get; set; }
    
    [DefaultValue(4)]
    public byte GuestsAmount { get; set; }
    public DateTime CreationDateTime { get; set; }
    
    [DefaultValue(60)]
    public int DurationInDays { get; set; }
    public DateTime EntryDate { get; set; }
}