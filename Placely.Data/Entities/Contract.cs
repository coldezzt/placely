using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class Contract : IEntity
{
    public long Id { get; set; }
    
    public long TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    
    public long LandlordId { get; set; }
    public virtual Landlord Landlord { get; set; }
    
    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }
    
    public string TemplatePath { get; set; }
    public string TemplateFieldsPath { get; set; }
    public string? FinalizedPathDocx { get; set; }
    public string? FinalizedPathPdf { get; set; }
    public DateTime LeaseStartDate { get; set; }
    public DateTime LeaseEndDate { get; set; }
}