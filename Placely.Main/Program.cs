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

var builder = WebApplication.CreateBuilder(args);

// Конфигурация
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

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
    .AddConfiguredJwtAuth(builder.Configuration);

// Настройка сервисов. Всё что НЕ возвращает IServiceCollection
builder.Services.AddControllers();
builder.Services.AddSignalR();

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
        });
}

// Различные using-и
application
    .UseMiddleware<ExceptionMiddleware>()
    .UseAuthentication()
    .UseAuthorization()
    .UseHttpsRedirection()
    .UseHangfireDashboard();

// Маппинг
application.MapControllers();
application.MapHub<ChatHub>("api/hubs/chat");

// Background задачи
RecurringJob.AddOrUpdate<IRatingUpdaterService>("Update rating", static service => service.UpdatePropertyRating(), "0 6 * * *");

// Запуск
application.Run();

// TODO: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа)
// TODO: добавить метод добавления в избранные property
// TODO: добавить метод фильтрования имуществ
// TODO: добавить методы изменения чувствительных данных в TenantController
// TODO: добавить методы загрузки файлов в чат и из него
// TODO: добавить логирование в сами методы бл
// TODO: добавить метод проверки 2FA у пользователя (для того чтобы только полностью зарегистрированный пользователь мог её настроить)
// TODO: добавить проверку на контактный адрес в добавлении имущества (если у создателя нет контактного адреса, возвращает 422)
// TODO: добавить проверку на то что один и тот же пользователь не может оставить несколько отзывов (пробежаться по другим сервисам/контроллерам на наличие такого же недочёта)
//? TODO: добавить аналогичные методы /my только для админов (чтобы они могли удалять и получать доступ к любому аккаунту)
//? TODO: придумать каким образом мне показать qr код для пользователя (в целом можно просто использовать ManualEntryKey)
//? TODO: добавить кастомный интерфейс для SwaggerUI

// TODO: [Вопрос] Узнать куда какие логи лучше записавыть. Пока предположение что все - в консоль, а важные - в файл - как считаешь правильным - объяснить
