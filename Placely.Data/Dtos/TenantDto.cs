using System.ComponentModel;

namespace Placely.Data.Dtos;

public class TenantDto
{ 
    [DefaultValue("Я обычный чувак, зарабатываю пол ляма в секунду, на выходных летаю на Мальдивы.")]
    public string About { get; set; }
    
    [DefaultValue("Работаю чуть-чуть там чуть-чуть здесь, подрабатывал дворником недавно. Доход стабильный короче)")]
    public string Work { get; set; }
    
    [DefaultValue("Мой адрес - не дом и не улица, мой адрес - Советский Союз.")]
    public string ContactAddress { get; set; }
}