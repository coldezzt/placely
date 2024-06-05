using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class PreviousPasswordEntityConfiguration : IEntityTypeConfiguration<PreviousPassword>
{
    public void Configure(EntityTypeBuilder<PreviousPassword> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.User)
            .WithMany(t => t.PreviousPasswords)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}