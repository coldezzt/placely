using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.EntityConfigurations;

public class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        /* TODO: add constraint directly to DB, not only in BL
         builder.ToTable(t => 
            t.HasCheckConstraint(
                "CHK_PropertyOwner", 
                "landlord_id = (select owner_id from properties as p where p.Id = property_id)"));*/
        builder.Property(c => c.TemplatePath)
            .HasDefaultValue("Data/contracts/default/default_template.docx");
        builder.Property(c => c.TemplateFieldsPath)
            .HasDefaultValue("Data/contracts/default/default_fields.json");
    }
}