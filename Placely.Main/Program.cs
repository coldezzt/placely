using Hangfire;
using Placely.Data.Abstractions.Services;
using Placely.Main.Controllers.Hubs;
using Placely.Main.Extensions;
using Placely.Main.Middlewares;
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

// DONE: НЕТ КОНТРОЛЛЕРА СОЗДАНИЯ ЗАЯВКИ (РЕЗЕРВАЦИИ)!!! - создан
// DONE: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа) - создан
// DONE: добавить метод добавления в избранные property - создан
// DONE: добавить логирование в сами методы бл - добавлено логирование в репозитории, в AppDbContext, в сервисы.
// DONE: добавить методы загрузки файлов в чат и из него - создан отдельный контроллер (использует те же сервисы что и ChatController
// DONE: добавить методы изменения чувствительных данных в TenantController - создано
// DONE: добавить метод проверки 2FA у пользователя (для того чтобы только полностью зарегистрированный пользователь мог её настроить) - добавлена проверка в метод сервиса (возвращает уже созданные токены в случае присутствия 2FA у пользвоателя)
// DONE: добавить проверку на контактный адрес в добавлении имущества (если у создателя нет контактного адреса, возвращает 422) - добавлено
// DONE: добавить проверку на то что один и тот же пользователь не может оставить несколько отзывов (пробежаться по другим сервисам/контроллерам на наличие такого же недочёта)
// DONE: задать дефолтные значения для полей (чтобы в swagger круто выглядело)
// DONE: убрать сборку делегата - заменить хардкодом, по причине того что EF не умеет разбирать предикат в sql запрос. (нашёл библу (уже установлена), проверить её работу)
//       - получилось вообще круто, ничего не пришлось удалять, немного подкорректировал работу с типами и предикатом и всё заработало
// DONE: добавить метод загрузки собственного шаблона договора и полей к нему - функционал удалён
// DONE: разобраться с путями для хэндлинга файлов - там по-моему вообще всё неправильно работает
// DONE: заменить IHostEnvironment и IConfiguration на IOptions<>

// TODO: Перед тем чтобы приступить к нижним TODO нужно сначала всё протестить и написать юз кейсы, а затем выкатить релиз скорее всего

//? TODO: починить чаты (signalR) - скорее всего они неверно работают (отправляют сообщения не только участникам чата, а ВСЕМ участникам хаба)
//? TODO: заменить почти все логи в конце методов на тип Debug - они не подходят под инфу т.к. всё равно слишком подробные, но и под Trace не подходят - не достаточно подробны.
//? TODO: разделить проект Placely.Data. реализация доступа к бд, абстракция доступа к бд, реализация сервисов, абстракции сервисов.
//? TODO: добавить аналогичные методы /my только для админов (чтобы они могли удалять и получать доступ к любому аккаунту)
//? TODO: придумать каким образом мне показать qr код для пользователя (в целом можно просто использовать ManualEntryKey)
//? TODO: не совсем нравится как работает авторизация, попробовать исправить.
//? TODO: заменить перебор значений из enum на метод применения фильтров в методе фильтрации имуществ
//? TODO: для быстроты работы можно создать задачу на создание документа (hangfire уже подключён) и присвоение его пути в сущности в базе данных, для этого нужно будет создать состояние документа (его готовность)
//? TODO: заменить все статусные коды на Enum StatusCodes из Microsoft.AspNetCore
//? TODO: добавить ограничение на оставление отзывов от владельца имущества
//? TODO: придумать что делать с отзывами на другие имущества у пользователя который стал владельцем
//? TODO: превращать пользователя во владельца после добавления имущества
//? TODO: проблема с удалением списков цен - они просто генерируются, а при удалении имущества список остаётся
//? TODO: добавить примеры путей для контроллера например: [HttpGet("my")] // api/chat/my/ - т.е. почти полный путь рядом с контроллером
//? TODO: заменить взаимодействие с файлами на в сервисах contract и chatfile на взаимодействие с единым сервисом, который будет уже разбиратьсяя только с файлами

// TODO: [Вопрос] Узнать куда какие логи лучше записавыть. Пока предположение что все - в консоль, а важные - в файл - как считаешь правильным - объяснить