using System.ComponentModel;
using Placely.Data.Models;

namespace Placely.Data.Dtos;

public class ReservationDto
{
    private static readonly TimeSpan _defaultTimeSpane = TimeSpan.FromDays(60);
    
    [DefaultValue(1)]
    public long Id { get; set; }

    [DefaultValue(1)]
    public long TenantId { get; set; }
    
    [DefaultValue(1)]
    public long LandlordId { get; set; }
    
    [DefaultValue(1)]
    public long PropertyId { get; set; }
    
    [DefaultValue(Models.ReservationStatus.Declined)]
    public ReservationStatus? ReservationStatus { get; set; }
    
    [DefaultValue("Сегодня ретроградный меркурий.")]
    public string? DeclineReason { get; set; }
    
    [DefaultValue(4)]
    public byte GuestsAmount { get; set; }
    public DateTime CreationDateTime { get; set; }
    
    [DefaultValue(60)]
    public int DurationInDays { get; set; }
    public DateTime EntryDate { get; set; }
}