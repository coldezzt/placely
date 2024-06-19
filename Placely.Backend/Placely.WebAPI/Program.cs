using Hangfire;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Common.Extensions;
using Placely.WebAPI.Middlewares;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

// Логирование на уровне приложения
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger.Information("Begin configuring application builder.");

    // Конфигурация
    builder.Configuration
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
    
    Log.Logger.Verbose("Added application configuration files.");

    // Добавление сервисов. Всё что возвращает IServiceCollection
    builder.Services
        .AddConfiguredSerilog(builder.Configuration)
        .AddRouting(static opt => opt.LowercaseUrls = true)
        .AddRepositories()
        .AddServices()
        .AddValidators()
        .AddMiddlewares()
        .AddDbContext(builder.Configuration)
        .AddEndpointsApiExplorer()
        .AddConfiguredSwaggerGen()
        .AddConfiguredAutoMapper()
        .AddConfiguredHangfire(builder.Configuration)
        .AddConfiguredJwtAuthentication(builder.Configuration);

    // Добавление сервисов. Всё что НЕ возвращает IServiceCollection
    builder.Services.AddControllers();
    builder.Services.AddSignalR();

    builder.Services.ConfigureServices(builder.Environment, builder.Configuration);

    Log.Logger.Verbose("Complete application services configuring.");

    Log.Logger.Information("Successfully configured application builder.");

    Log.Logger.Information("Begin building application.");
    
    // Сборка приложения
    var application = builder.Build();

    application
        .UseSerilogRequestLogging();

    if (application.Environment.IsDevelopment())
    {
        application
            .UseSwagger()
            .UseSwaggerUI(static options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Placely API v1");
                options.DocExpansion(DocExpansion.None);
            });
        
        Log.Logger.Verbose("Added SwaggerUI to application pipeline.");
    }

    // Различные using-и
    application
        .UseMiddleware<ExceptionMiddleware>()
        .UseAuthentication()
        .UseAuthorization()
        .UseHttpsRedirection()
        .UseHangfireDashboard();
    
    Log.Logger.Verbose("Added usings to application.");

    // Маппинг
    application.MapControllers();
    // application.MapHub<ChatHub>("api/hubs/chat"); в разработке :(
    
    Log.Logger.Verbose("Successfully mapped endpoints in application.");

    // Background задачи
    RecurringJob.AddOrUpdate<IRatingUpdaterService>("Update rating", static service => service.UpdatePropertyRating(),
        "0 6 * * *");
    
    Log.Logger.Verbose("Successfully create recurring jobs for application.");

    Log.Logger.Information("Successfully built an application.");
    
    Log.Logger.Information("Begin booting application.");
    
    // Запуск
    application.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal("Unhandled error. {@ex}", ex);
}

/* 
 TODO: [IN PROGRESS] Release v2
 
 TODO: [IN PROGRESS] make proper public Postman workspace
 TODO: перенести задачи ниже в YouTrack
 TODO: метод остановки действия контракта (расторгнут)
 TODO: для быстроты работы можно создать задачу на создание документа (hangfire уже подключён) и присвоение его пути в сущности в базе данных, для этого нужно будет создать состояние документа (его готовность)
 TODO: добавить ограничение на оставление отзывов от владельца имущества
 TODO: придумать что делать с отзывами на другие имущества у пользователя который стал владельцем
 TODO: заменить взаимодействие с файлами в сервисах contract и chatfile на взаимодействие с единым сервисом, который будет уже разбираться только с файлами
 TODO: [architecture] не унифицированные методы контроллеров - где-то делаю проверку прямо в контроллере, а где-то в сервисе, из-за чего может возникнуть путанница. Пример тому: методы Get и Update в ReservationController
 TODO: [optimization] избавиться от LazyLoading - как оказалось это медленная технология (хоть и удобная) :(
 TODO: [scaling] засунуть всё в Docker
*/