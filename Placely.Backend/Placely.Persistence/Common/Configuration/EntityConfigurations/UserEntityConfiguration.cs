using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;

namespace Placely.Persistence.Common.Configuration.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder
            .Property(u => u.UserRole)
            .HasDefaultValue(UserRoleType.Tenant);

        builder
            .HasMany(u => u.PreviousPasswords)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.TenantId)
            .IsRequired();

        builder
            .HasMany(u => u.OwnedProperties)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId)
            .IsRequired();

        builder
            .HasMany(u => u.Favourites)
            .WithMany(p => p.Favourites);

        builder
            .HasMany(u => u.Chats)
            .WithMany(c => c.Participants);
        
        builder
            .HasMany(u => u.Messages)
            .WithOne(m => m.Author)
            .HasForeignKey(m => m.AuthorId)
            .IsRequired();

        builder
            .HasMany(u => u.Notifications)
            .WithOne(n => n.Receiver)
            .HasForeignKey(n => n.ReceiverId)
            .IsRequired();

        builder
            .HasMany(u => u.Reservations)
            .WithMany(r => r.Participants);
        
        builder
            .HasMany(u => u.Reviews)
            .WithOne(r => r.Author)
            .HasForeignKey(r => r.AuthorId)
            .IsRequired();

        builder.Property(u => u.IsAdditionalRegistrationRequired)
            .HasDefaultValue(false);

        builder.Property(u => u.IsTwoFactorEnabled)
            .HasDefaultValue(false);
    }
}