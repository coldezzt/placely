using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;
using Placely.Domain.Enums;

namespace Placely.Infrastructure.Configuration.EntityConfigurations;

public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.StatusType)
            .HasDefaultValue(ReservationStatusType.Opened);
    }
}