using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Infrastructure.Configuration.EntityConfigurations;

public class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.Property(c => c.TemplatePath)
            .HasDefaultValue("Data/contracts/default/default_template.docx");
        builder.Property(c => c.TemplateFieldsPath)
            .HasDefaultValue("Data/contracts/default/default_fields.json");
    }
}