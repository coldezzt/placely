using System.ComponentModel;
using Placely.Domain.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи данных о резервировании.")]
public class ReservationDto
{
    [SwaggerSchema("Идентификатор резервирования.")]
    [DefaultValue(1)]
    public long Id { get; set; }

    [SwaggerSchema("Идентификатор арендатора.")]
    [DefaultValue(1)]
    public long TenantId { get; set; }
    
    [SwaggerSchema("Идентификатор арендодателя.")]
    [DefaultValue(1)]
    public long LandlordId { get; set; }
    
    [SwaggerSchema("Идентификатор имущества.")]
    [DefaultValue(1)]
    public long PropertyId { get; set; }

    [SwaggerSchema("Статус резервирования.")]
    [DefaultValue(ReservationStatusType.Declined)]
    public ReservationStatusType StatusType { get; set; } = ReservationStatusType.Undefined;
    
    [SwaggerSchema("Причина отказа в заявке.")]
    [DefaultValue("Сегодня ретроградный меркурий.")]
    public string? DeclineReason { get; set; }
    
    [SwaggerSchema("Предположительное количество гостей в период аренды.")]
    [DefaultValue(4)]
    public byte GuestsAmount { get; set; }

    [SwaggerSchema("Дата создания резервирования.")]
    public DateTime CreationDateTime { get; set; }
    
    [SwaggerSchema("Длительность резервирования в днях.")]
    [DefaultValue(60)]
    public int DurationInDays { get; set; }

    [SwaggerSchema("Дата начала аренды.")]
    public DateTime EntryDate { get; set; }
}