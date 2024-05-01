using Hangfire;
using Placely.Data.Abstractions.Services;
using Placely.Main.Controllers.Hubs;
using Placely.Main.Extensions;
using Placely.Main.Middlewares;
using Serilog;

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
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
    Log.Logger.Verbose("Added application configuration files.");
    
    // Настройка сервисов. Всё что возвращает IServiceCollection
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

    // Настройка сервисов. Всё что НЕ возвращает IServiceCollection
    builder.Services.AddControllers();
    builder.Services.AddSignalR();

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
            .UseSwaggerUI(static options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Placely API v1"); });
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
    application.MapHub<ChatHub>("api/hubs/chat");
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

// DONE: НЕТ КОНТРОЛЛЕРА СОЗДАНИЯ ЗАЯВКИ (РЕЗЕРВАЦИИ)!!!
// DONE: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа)
// DONE: добавить метод добавления в избранные property
// DONE: добавить логирование в сами методы бл
// DONE: добавить методы загрузки файлов в чат и из него
// TODO: добавить методы изменения чувствительных данных в TenantController
// TODO: добавить метод проверки 2FA у пользователя (для того чтобы только полностью зарегистрированный пользователь мог её настроить)
// TODO: добавить проверку на контактный адрес в добавлении имущества (если у создателя нет контактного адреса, возвращает 422)
// TODO: добавить проверку на то что один и тот же пользователь не может оставить несколько отзывов (пробежаться по другим сервисам/контроллерам на наличие такого же недочёта)
// TODO: задать дефолтные значения для полей (чтобы в swagger круто выглядело)
// TODO: починить чаты - скорее всего они неверно работают (отправляют сообщения не только участникам чата, а ВСЕМ участникам хаба)
// TODO: добавить метод фильтрования имуществ, убрать сборку делегата - заменить хардкодом, по причине того что EF не умеет разбирать предикат в sql запрос. (нашёл библу (уже установлена), проверить её работу)

//? TODO: разделить проект Placely.Data. реализация доступа к бд, абстракция доступа к бд, реализация сервисов, абстракции сервисов.
//? TODO: добавить аналогичные методы /my только для админов (чтобы они могли удалять и получать доступ к любому аккаунту)
//? TODO: придумать каким образом мне показать qr код для пользователя (в целом можно просто использовать ManualEntryKey)
//? TODO: не совсем нравится как работает авторизация, попробовать исправить.

// TODO: [Вопрос] Узнать куда какие логи лучше записавыть. Пока предположение что все - в консоль, а важные - в файл - как считаешь правильным - объяснить
