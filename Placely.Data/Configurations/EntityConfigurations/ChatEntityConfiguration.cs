using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.EntityConfigurations;

public class ChatEntityConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        /* TODO: добавить вместе с другим ограничением в бд
         builder
            // так как мне нужна уникальность по двум ключам - идентификаторам пользователей,
            // я беру эти два числа, сортирую их, и превращаю в строку - таким образом из-за сортировки не будет
            // дубликатов типа: чат-10-16 -И- чат-16-10 (чат один и тот же, просто из-за инициатора разные названия)
            .HasIndex(static c => string.Join(" ", new {c.FirstUserId, c.SecondUserId}))
            .IsUnique();
            */
        
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