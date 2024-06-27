using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи сообщения")]
public class MessageDto
{
    [SwaggerSchema("Идентификатор сообщения.")]
    [DefaultValue(1)]
    public long Id { get; set; }
    
    [SwaggerSchema("Идентификатор чата.")]
    [DefaultValue(1)]
    public long ChatId { get; set; }
    
    [SwaggerSchema("Идентификатор автора.")]
    [DefaultValue(1)]
    public long AuthorId { get; set; }
    
    [SwaggerSchema("Содержимое сообщения.")]
    [DefaultValue("Привет, мир!")]
    public string Content { get; set; }

    [SwaggerSchema("Дата отправки сообщения.")]
    public DateTime Date { get; set; }

    [SwaggerSchema("Название файла для прикрепления к этому сообщению.")]
    [DefaultValue("filename.txt")]
    public string? FileName { get; set; }
}