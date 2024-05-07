using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Configurations.EntityConfigurations;

public class TenantEntityConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(static t => t.UserRole)
            .HasDefaultValue(UserRole.Tenant);

        builder.Property(static t => t.IsAdditionalRegistrationRequired)
            .HasDefaultValue(false);

        builder.Property(static t => t.IsTwoFactorEnabled)
            .HasDefaultValue(false);
    }
}