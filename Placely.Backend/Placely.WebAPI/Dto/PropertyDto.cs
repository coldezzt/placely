using System.ComponentModel;
using Placely.Domain.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи данных о имуществе.")]
public class PropertyDto
{
    [SwaggerSchema("Идентификатор имущества.")]
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [SwaggerSchema("Идентификатор владельца имущества.")]
    [DefaultValue(1)]
    public long OwnerId { get; set; }
    
    [SwaggerSchema("Тип имущества.")]
    [DefaultValue(PropertyType.Flat)]
    public PropertyType Type { get; set; }

    [SwaggerSchema("Адрес имущества. Перед этим отформатирован с помощью Dadata.")]
    [DefaultValue("г Москва, ул Хабаровская, д 3, кв 10")]
    public string Address { get; set; }
    
    [SwaggerSchema("Описание имущества.")]
    [DefaultValue("Это моя очень крутая квартира. Недавно сделал ремонт! " +
                  "А это много дополнительного текста, для того, чтобы я прошёл валидацию!")]
    public string Description { get; set; }
    
    [SwaggerSchema("Дата публикации имущества.")]
    public DateTime PublicationDate { get; set; }
    
    [SwaggerSchema("Рейтинг имущества. От 0.0 до 5.0")]
    [DefaultValue(5.0d)]
    public double Rating { get; set; }
    
    [SwaggerSchema("Стоимость аренды имущества на короткий промежуток времени. " +
                   "Длительность определяется Пользовательским соглашением.")]
    [DefaultValue(54000)]
    public ushort ShortPeriodPayment { get; set; }
    
    [SwaggerSchema("Стоимость аренды имущества на небольшой промежуток времени. " +
                   "Длительность определяется Пользовательским соглашением.")]
    [DefaultValue(48000)]
    public ushort MediumPeriodPayment { get; set; }
    
    [SwaggerSchema("Стоимость аренды имущества на большой промежуток времени. " +
                   "Длительность определяется Пользовательским соглашением.")]
    [DefaultValue(30000)]
    public ushort LongPeriodPayment { get; set; }
}