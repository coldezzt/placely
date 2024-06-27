using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId)
            .IsRequired();

        builder
            .HasOne(m => m.Author)
            .WithMany(t => t.Messages)
            .HasForeignKey(m => m.AuthorId)
            .IsRequired();
    }
}