using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Chat : IEntity
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    
    public long LandlordId { get; set; }
    public virtual Landlord Landlord { get; set; }
    
    // TODO: сделать свойство - методом генерирующим путь (метод получится дешевле чем хранить строки)
    public string DirectoryPath { get; set; }
    
    public virtual List<Message> Messages { get; set; }
}