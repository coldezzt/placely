using Hangfire;
using Placely.Data.Abstractions.Services;
using Placely.Main.Controllers.Hubs;
using Placely.Main.Extensions;
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
    .AddRouting(opt => opt.LowercaseUrls = true)
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
        .UseSwaggerUI();
}

// Различные using-и
application
    // .UseMiddleware<ExceptionMiddleware>()
    .UseAuthentication()
    .UseAuthorization()
    .UseHttpsRedirection()
    .UseHangfireDashboard();

// Маппинг
application.MapControllers();
application.MapHub<ChatHub>("api/hubs/chat");

// Background задачи
RecurringJob.AddOrUpdate<IRatingUpdaterService>("Update rating", service => service.UpdatePropertyRating(), "0 6 * * *");

// Запуск
application.Run();

// TODO: вынести "api" из каждого контроллера сюда.
// TODO: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа)
// TODO: пробежаться по роутам и навесить на параметры внутри ограничения на тип
// TODO: убрать проверки форматирования (к пред. задаче) (для примера посмотреть на ReviewController)
// TODO: добавить метод добавления в избранные property
// TODO: добавить методы изменения чувствительных данных в TenantController
// TODO: добавить методы загрузки файлов в чат и из него
// TODO: добавить логирование в сами методы бл
// TODO: добавить аналогичные методы /my только для админов (чтобы они могли удалять и получать доступ к любому аккаунту)
// TODO: придумать каким образом мне показать qr код для пользователя (в целом можно просто использовать ManualEntryKey)

// TODO: [Вопрос] 2FA должна быть обязательна или доступна на сайте? - если просто доступна - легче тестировать
// TODO: [Вопрос] Узнать куда какие логи лучше записавыть. Пока предположение что все - в консоль, а важные - в файл - как считаешь правильным - объяснить
// TODO: [Вопрос] Узнать нужно ли в пустые возвраты по типу Ok() или BadRequest() засунуть строки с ошибками или с результами, или объекты туда засунуть?