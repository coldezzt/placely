using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Configuration.EntityConfigurations;

public class ChatEntityConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder
            .HasOne(c => c.FirstUser)
            .WithMany()
            .HasForeignKey(c => c.FirstUserId);
        builder
            .HasOne(c => c.SecondUser)
            .WithMany()
            .HasForeignKey(c => c.SecondUserId);
    }
}