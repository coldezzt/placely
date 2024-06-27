using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class PriceListEntityConfiguration : IEntityTypeConfiguration<PriceList>
{
    public void Configure(EntityTypeBuilder<PriceList> builder)
    {
        builder.HasKey(pl => pl.Id);

        builder
            .HasOne(pl => pl.Property)
            .WithOne(p => p.PriceList)
            .HasForeignKey<Property>(p => p.PriceListId)
            .IsRequired();
    }
}