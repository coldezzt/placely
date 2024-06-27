using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Domain.Common.Enums;

[SwaggerSchema("Тип имущества.")]
public enum PropertyType
{
    /// <summary>
    /// Хостел.
    /// </summary>
    Hostel,
    
    /// <summary>
    /// Комната.
    /// </summary>
    Room,
    
    /// <summary>
    /// Квартира, апартаменты.
    /// </summary>
    Flat,
    
    /// <summary>
    /// Вилла, коттедж.
    /// </summary>
    Villa
}