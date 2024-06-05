using System.ComponentModel;
using Placely.Domain.Common.Enums;

namespace Placely.WebAPI.Dto;

public class PropertyDto
{
    [DefaultValue(1)]
    public long Id { get; set; }
    [DefaultValue(1)]
    public long OwnerId { get; set; }
    
    [DefaultValue(PropertyType.Flat)]
    public PropertyType Type { get; set; }

    [DefaultValue("г Москва, ул Хабаровская, д 3, кв 10")]
    public string Address { get; set; }
    
    [DefaultValue("Это моя очень крутая квартира. Недавно сделал ремонт! " +
                  "А это много дополнительного текста, для того, чтобы я прошёл валидацию!")]
    public string Description { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
    [DefaultValue(5.0d)]
    public double Rating { get; set; }
    
    [DefaultValue(54000)]
    public ushort ShortPeriodPayment { get; set; }
    
    [DefaultValue(48000)]
    public ushort MediumPeriodPayment { get; set; }
    
    [DefaultValue(30000)]
    public ushort LongPeriodPayment { get; set; }
}