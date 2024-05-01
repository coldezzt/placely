using System.ComponentModel;

namespace Placely.Data.Dtos;

public class ContractCreationDto
{
    [DefaultValue(4)]
    public long ReservationId { get; set; }

    [DefaultValue(13_299.54)]
    public decimal PaymentAmount { get; set; }

    [DefaultValue("1 раз в месяц")]
    public string PaymentFrequency { get; set; }

    [DefaultValue("/api/data/contracts/default/default_template.docx")]
    public string PathToTemplate { get; set; }

    [DefaultValue("/api/data/contracts/default/default-fields.json")]
    public string PathToTemplateFields { get; set; }
}