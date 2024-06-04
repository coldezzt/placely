using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class ContractCreationDto
{
    [DefaultValue(4)]
    public long ReservationId { get; set; }

    [DefaultValue(13_299.54)]
    public decimal PaymentAmount { get; set; }

    [DefaultValue("1 раз в месяц")]
    public string PaymentFrequency { get; set; }
}