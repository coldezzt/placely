namespace BL.Entities;

public class Chat
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public long LandlordId { get; set; }
    public Landlord Landlord { get; set; }
    
    public string DirectoryPath { get; set; }
    
    public List<Message> Messages { get; set; }
}