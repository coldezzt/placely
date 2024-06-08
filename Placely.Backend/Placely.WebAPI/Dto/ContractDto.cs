using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;


[SwaggerSchema("Объект для передачи данных о контракте.")]
public class ContractDto
{
    [SwaggerSchema("Идентификатор контракта.")]
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [SwaggerSchema("Идентификатор резервирования, относящегося к этому контракту.")]
    [DefaultValue(1)]
    public long ReservationId { get; set; }
    
    [SwaggerSchema("Путь до файла контракта в формате DOCX")]
    [DefaultValue("/contract_1/dated_2024-05-01T12:36:45.165Z_with_1.docx")]
    public string DocxPath { get; set; }
    
    [SwaggerSchema("Путь до файла контракта в формате PDF")]
    [DefaultValue("/contract_1/dated_2024-05-01T12:36:45.165Z_with_1.pdf")]
    public string PdfPath { get; set; }
}