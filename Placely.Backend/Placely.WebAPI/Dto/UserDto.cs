using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Dto;

[SwaggerSchema("Объект для передачи общих данных пользователя.")]
public class UserDto
{ 
    [SwaggerSchema("О пользователе.")]
    [DefaultValue("Я обычный чувак, зарабатываю пол ляма в секунду, на выходных летаю на Мальдивы.")]
    public string About { get; set; }
    
    [SwaggerSchema("О работе пользователя.")]
    [DefaultValue("Работаю чуть-чуть там чуть-чуть здесь, подрабатывал дворником недавно. Доход стабильный короче)")]
    public string Work { get; set; }
    
    [SwaggerSchema("Контактный адрес пользователя.")]
    [DefaultValue("Мой адрес - не дом и не улица, мой адрес - Советский Союз.")]
    public string ContactAddress { get; set; }
}