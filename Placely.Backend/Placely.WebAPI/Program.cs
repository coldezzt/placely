using Hangfire;
using Placely.WebAPI.Abstractions.Services;
using Placely.WebAPI.Extensions;
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
    Log.Logger.Error("Unhandled error. {@ex}", ex);
}
