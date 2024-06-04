using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Infrastructure.Configuration.EntityConfigurations;

public class PropertyEntityConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder
            .HasIndex(p => p.PriceListId)
            .IsUnique();

        builder
            .HasOne(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.OwnerId);
    }
}