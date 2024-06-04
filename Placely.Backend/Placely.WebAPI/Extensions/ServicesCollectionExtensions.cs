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
using Placely.Application.Abstractions.Repositories;
using Placely.Application.Configuration.DestructingPolicies;
using Placely.Application.Options;
using Placely.Application.Services;
using Placely.Domain.Abstractions.Services;
using Placely.Persistence;
using Placely.Persistence.Repositories;
using Placely.WebAPI.Configuration.Mapper;
using Placely.WebAPI.Dto;
using Placely.WebAPI.Dto.Validators;
using Placely.WebAPI.Middlewares;
using Serilog;
using Serilog.Events;

namespace Placely.WebAPI.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IHostEnvironment env,
        IConfiguration configuration)
    {
        services.Configure<CommonOptions>(options =>
        {
            options.ContentRootPath = env.ContentRootPath;
            options.IsProduction = env.IsProduction();
        });
        services.Configure<ContractServiceOptions>(configuration.GetSection("ContractGeneration"));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<ILandlordRepository, LandlordRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();

        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IDadataAddressService, DadataAddressService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IRatingUpdaterService, RatingUpdaterService>();
        
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
        services.AddScoped<IValidator<SensitiveTenantDto>, SensitiveTenantDtoValidator>();
        services.AddScoped<IValidator<TenantDto>, TenantDtoValidator>();
        
        // Чтобы валидаторы не продолжали валидацию после первой же ошибки.
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop; 
        
        return services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
        
        return services;
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection collection, IConfiguration configuration)
    {
        return collection.AddDbContext<AppDbContext>(builder => 
            builder.UseNpgsql(configuration["Database:ConnectionString"]));
    }

    public static IServiceCollection AddConfiguredJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
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
            .AddCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToLogout = context => Task.FromResult("Logout!");
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToReturnUrl = context => Task.FromResult("RedirectToReturnUrl!");
            })
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
                            - 302 статус. Сервер перенаправляет на страницу с авторизацией, 
                            т.к. пользователь не авторизован. Либо перенаправляет на Google для авторизации.
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
                new ReservationMapperProfile(),
                new ReviewMapperProfile(),
                new TenantMapperProfile(),
                new ValidationFailureMapperProfile(),
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
        services.AddSerilog((servs, loggerConfiguration) =>
        {
            loggerConfiguration
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(servs)

                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
                // .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Hangfire", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.SignalR", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Server", LogEventLevel.Warning)
                
                .Destructure.ToMaximumStringLength(128)
                .Destructure.With(
                    new ChatDestructingPolicy(),
                    new ContractDestructingPolicy(),
                    new MessageDestructingPolicy(),
                    new NotificationDestructingPolicy(),
                    new PreviousPasswordDestructingPolicy(),
                    new PropertyDestructingPolicy(),
                    new ReservationDestructionProperty(),
                    new ReviewDestructionPolicy(),
                    new TenantDestructingPolicy()
                )

                .Enrich.FromLogContext();
        });

        return services;
    }
}