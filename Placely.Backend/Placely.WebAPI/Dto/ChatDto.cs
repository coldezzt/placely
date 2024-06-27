using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи данных о чатах.")]
public class ChatDto
{
    [SwaggerSchema("Идентификатор чата.")]
    [DefaultValue(1)]
    public long Id { get; set; }

    [SwaggerSchema("Участники чата.")]
    public List<long> Participants { get; set; } = new();
}