using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Configurations;
using Placely.Data.Dtos;
using Placely.Data.Entities.Validators;
using Placely.Data.Repositories;
using Placely.Main.Services;

namespace Placely.Main.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IPropertyService, PropertyService>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<PropertyDto>, PropertyDtoValidator>();

        return services;
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection collection,
        IConfiguration configuration)
    {
        return collection.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseNpgsql(configuration["Database:ConnectionString"]);
            builder.UseSnakeCaseNamingConvention();
        });
    }

    public static IServiceCollection ConfigureJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]!)
                    ),
                    ValidateIssuerSigningKey = true,
                };
            });
        return services;
    }
}