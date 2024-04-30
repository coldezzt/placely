using System.Text;
using AutoMapper;
using FluentValidation;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Configurations;
using Placely.Data.Configurations.Mapper;
using Placely.Data.Dtos;
using Placely.Data.Dtos.Validators;
using Placely.Data.Repositories;
using Placely.Main.Middlewares;
using Placely.Main.Policies.DestructingPolicies;
using Placely.Main.Services;
using Serilog;
using Serilog.Events;

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
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<ILandlordService, LandlordService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IRatingUpdaterService, RatingUpdaterService>();
        services.AddScoped<IDadataAddressService, DadataAddressService>();
        
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AuthorizationDto>, AuthorizationDtoValidator>();
        services.AddScoped<IValidator<ChatDto>, ChatDtoValidator>();
        services.AddScoped<IValidator<MessageDto>, MessageDtoValidator>();
        services.AddScoped<IValidator<PropertyDto>, PropertyDtoValidator>();
        services.AddScoped<IValidator<RegistrationDto>, RegistrationDtoValidator>();
        services.AddScoped<IValidator<ReservationDto>, ReservationDtoValidator>();
        services.AddScoped<IValidator<ReviewDto>, ReviewDtoValidator>();
        services.AddScoped<IValidator<TenantDto>, TenantDtoValidator>();
        
        return services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
        
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

    public static IServiceCollection AddConfiguredJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtAuth:JwtSecurityKey"]!)),
                    ValidateLifetime = false
                };
            })
            .AddCookie(options =>options.LoginPath = "/api/authorize")
            .AddGoogle(options =>
            {
                var googleConfig = configuration.GetSection("Authentication:Google");
                options.ClientId = googleConfig["ClientId"]!;
                options.ClientSecret = googleConfig["ClientSecret"]!;
            });
        services.AddAuthorization();
        
        return services;
    }

    public static IServiceCollection AddConfiguredSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(static opt =>
        {
            opt.SwaggerDoc(
                name: "v1", 
                info: new OpenApiInfo
                    {
                        Title = "Placely API", 
                        Version = "v1",
                        Description = 
                            """
                            Placely API предоставляет возможность полностью взаимодействовать с сайтом Placely.
                            
                            Все конечные точки, которые имеют в названии `/my` подразумевают авторизацию и достают 
                            данные **только** для авторизованного пользователя. Например, путь: `/chat/my/list` - 
                            подразумевает получение всех чатов **текущего авторизованного пользователя**.
                            
                            Все конечные точки так или иначе взаимодействуют с базой данных. Исходя из этого
                            все конечные точки так же могут вернуть:
                            - 404 статус. Сервер не смог найти какой-то объект из-запроса в базе данных.
                            - 503 статус. Какие-то проблемы с базой данных.
                            - 500 статус. Возвращается при незадокументированном исключении.
                            """,
                        Contact = new OpenApiContact
                        {
                            Name = "Placely",
                            Url = new Uri("https://example.com/"),
                            Email = "ruzan.valeeff@yandex.ru"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Placely_License_v1.4.2",
                            Url = new Uri("https://example.com/")
                        }
                    }
                );
            opt.EnableAnnotations();
            opt.AddSignalRSwaggerGen();
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        
        
        return services;
    }

    public static IServiceCollection AddConfiguredAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(static cfg =>
        {
            cfg.AddProfiles(new List<Profile>
            {
                new AuthorizationMapperProfile(),
                new ChatMapperProfile(),
                new ContractMapperProfile(),
                new MessageMapperProfile(),
                new PropertyMapperProfile(),
                new RegistrationMapperProfile(),
                new ReviewMapperProfile(),
                new TenantMapperConfiguration(),
            });
        });
        return services;
    }

    public static IServiceCollection AddConfiguredHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(opt =>
        {
            opt.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(c => 
                    c.UseNpgsqlConnection(configuration["Database:HangfireConnectionString"]));
        });
        
        services.AddHangfireServer();
        return services;
    }

    public static IServiceCollection AddConfiguredSerilog(this IServiceCollection services, IConfiguration configuration)
    { 
        services.AddSerilog((servs, lc) => 
            lc
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                
                .Destructure.ToMaximumStringLength(1024)
                .Destructure.With(
                    new ContractDestructingPolicy(),
                    new MessageDestructingPolicy(),
                    new NotificationDestructingPolicy(),
                    new PreviousPasswordDestructingPolicy(),
                    new PropertyDestructingPolicy(),
                    new ReservationDestructionProperty(),
                    new ReviewDestructionPolicy(),
                    new TenantDestructingPolicy()
                    )
                
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(servs)
                .Enrich.FromLogContext()
            );
        return services;
    }
}