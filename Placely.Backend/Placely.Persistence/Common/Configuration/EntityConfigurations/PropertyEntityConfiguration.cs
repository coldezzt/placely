using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class PropertyEntityConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Owner)
            .WithMany(t => t.OwnedProperties)
            .HasForeignKey(p => p.OwnerId)
            .IsRequired();

        builder
            .HasOne(p => p.PriceList)
            .WithOne(pl => pl.Property)
            .HasForeignKey<Property>(p => p.PriceListId)
            .IsRequired();

        builder
            .HasMany(p => p.Reviews)
            .WithOne(r => r.Property)
            .HasForeignKey(r => r.PropertyId)
            .IsRequired();

        builder
            .HasMany(p => p.Reservations)
            .WithOne(r => r.Property)
            .HasForeignKey(r => r.PropertyId)
            .IsRequired();

        builder
            .HasMany(p => p.Favourites)
            .WithMany(t => t.Favourites);
        
        builder
            .HasIndex(p => p.PriceListId)
            .IsUnique();
    }
}