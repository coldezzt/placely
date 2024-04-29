namespace Placely.Data.Dtos;

public class ContractCreationDto
{
    public long ReservationId { get; set; }
    public decimal PaymentAmount { get; set; }
    public string PaymentFrequency { get; set; }
    public string PathToTemplate { get; set; }
    public string PathToTemplateFields { get; set; }
}