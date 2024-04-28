namespace Placely.Data.Dtos;

public class ContractDto
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public long LandlordId { get; set; }
    public long PropertyId { get; set; }
    public string DocxPath { get; set; }
    public string PdfPath { get; set; }
    public DateTime LeaseStartDateTime { get; set; }
    public DateTime LeaseEndDateTime { get; set; }
}