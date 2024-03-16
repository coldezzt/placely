using BL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BL.Configurations;

public class PropertyEntityConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder
            .HasOne<PriceList>(p => p.PriceList)
            .WithOne(p => p.Property)
            .HasForeignKey<Property>(p => p.Id);
    }
}