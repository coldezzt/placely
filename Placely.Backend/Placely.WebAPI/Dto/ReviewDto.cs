using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи данных о отзывах на имущество.")]
public class ReviewDto
{
    [SwaggerSchema("Идентификатор отзыва.")]
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [SwaggerSchema("Идентификатор автора отзыва.")]
    [DefaultValue(1)]
    public long AuthorId { get; set; }

    [SwaggerSchema("Идентификатор имущества.")]
    [DefaultValue(1)]
    public long PropertyId { get; set; }
    
    [SwaggerSchema("Рейтинг отзыва.")]
    [DefaultValue(4.3)]
    public double Rating { get; set; }

    [SwaggerSchema("Дата создания отзыва.")]
    public DateTime Date { get; set; }
    
    [SwaggerSchema("Содержимое отзыва.")]
    [DefaultValue("Очень крутой дом! Нам понравилось!")]
    public string Content { get; set; }
}