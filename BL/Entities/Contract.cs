namespace BL.Entities;

public class Contract
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public long LandlordId { get; set; }
    public Landlord Landlord { get; set; }
    
    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public string TenantPaidUtilies { get; set; }
    public DateTime LeaseStartDate { get; set; }
    public DateTime LeaseEndDate { get; set; }
}