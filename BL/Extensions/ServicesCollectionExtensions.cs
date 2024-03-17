using Microsoft.EntityFrameworkCore;

namespace BL.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection collection,
        IConfiguration configuration)
    {
        // TODO: реализовать и добавить все репозитории сюда
        
        return collection.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseNpgsql(configuration["Database:ConnectionString"]);
            builder.UseSnakeCaseNamingConvention();
        });
    }
}