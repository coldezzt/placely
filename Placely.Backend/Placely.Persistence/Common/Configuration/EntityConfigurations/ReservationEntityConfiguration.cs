using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasOne(r => r.Property)
            .WithMany(p => p.Reservations)
            .HasForeignKey(r => r.PropertyId)
            .IsRequired();
            
        builder
            .HasOne(r => r.Contract)
            .WithOne(c => c.Reservation)
            .HasForeignKey<Contract>(c => c.ReservationId)
            .IsRequired(false);

        builder
            .HasMany(r => r.Participants)
            .WithMany(u => u.Reservations);
        
        builder.Property(r => r.Status)
            .HasDefaultValue(ReservationStatus.Opened);
    }
}