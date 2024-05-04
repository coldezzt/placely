using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Configurations.EntityConfigurations;

public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.ReservationStatus)
            .HasDefaultValue(ReservationStatus.Opened);
    }
}