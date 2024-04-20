namespace Placely.Data.Entities;

public class PreviousPassword
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    
    public string Password { get; set; }
}