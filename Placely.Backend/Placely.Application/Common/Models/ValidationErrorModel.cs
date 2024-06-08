using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Application.Common.Models;

[SwaggerSchema("Модель для передачи данных об ошибках валидации.")]
public class ValidationErrorModel
{
    [SwaggerSchema("Название свойства с ошибкой.")]
    [DefaultValue("Description")]
    public string PropertyName { get; set; }
    
    [SwaggerSchema("Сообщение с ошибкой.")]
    [DefaultValue("Длина поля должна быть более 256 символов!")]
    public string ErrorMessage { get; set; }
    
    [SwaggerSchema("Значение, которое вызвало ошибку.")]
    [DefaultValue("Я тут написал немного текста...")]
    public object AttemptedValue { get; set; }
}