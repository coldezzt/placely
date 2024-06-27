using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasOne(r => r.Author)
            .WithMany(t => t.Reviews)
            .HasForeignKey(r => r.AuthorId)
            .IsRequired();

        builder
            .HasOne(r => r.Property)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.PropertyId)
            .IsRequired();
    }
}