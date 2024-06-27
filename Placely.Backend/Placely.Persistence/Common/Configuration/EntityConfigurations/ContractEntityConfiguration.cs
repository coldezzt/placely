using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Reservation)
            .WithOne(r => r.Contract)
            .HasForeignKey<Contract>(c => c.ReservationId)
            .IsRequired();
    }
}