using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;
using Placely.Domain.Enums;

namespace Placely.Infrastructure.Configuration.EntityConfigurations;

public class TenantEntityConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(static t => t.UserRole)
            .HasDefaultValue(UserRoleType.Tenant);

        builder.Property(static t => t.IsAdditionalRegistrationRequired)
            .HasDefaultValue(false);

        builder.Property(static t => t.IsTwoFactorEnabled)
            .HasDefaultValue(false);
    }
}