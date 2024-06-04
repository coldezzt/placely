using System.ComponentModel;

namespace Placely.WebAPI.Dto;

public class ContractDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [DefaultValue(1)]
    public long TenantId { get; set; }
    
    [DefaultValue(1)]
    public long LandlordId { get; set; }
    
    [DefaultValue(1)]
    public long PropertyId { get; set; }
    
    [DefaultValue("/contract_1/dated_2024-05-01T12:36:45.165Z_with_1.docx")]
    public string DocxPath { get; set; }
    
    [DefaultValue("/contract_1/dated_2024-05-01T12:36:45.165Z_with_1.pdf")]
    public string PdfPath { get; set; }
    
    public DateTime LeaseStartDateTime { get; set; }
    public DateTime LeaseEndDateTime { get; set; }
}