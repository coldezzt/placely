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
    Log.Logger.Error("Unhandled error. {@ex}", ex);
}

/*
DONE:   Перед тем чтобы приступить к нижним задачам нужно сначала всё протестить и написать юз кейсы, а затем выкатить релиз скорее всего
        use-case созданы в Postman, релиз выкачен, разработка продолжается
        
DONE:   разделить проект Placely.Data. реализация доступа к бд, абстракция доступа к бд, реализация сервисов, абстракции сервисов
        разделены оба проекта, осуществлён переход на Clean архитектуру

DONE:   Внести мелкие правки в Clean архитектуру, перенести авторизацию в другой проект, подправить входные и выходные параметры в сервисах
        подправил хэндлинг токенов авторизации и сам сервис авторизации вместе с абстракцией теперь лежит в Placely.Infrastructure

DONE:   придумать каким образом мне показать qr код для пользователя (в целом можно просто использовать ManualEntryKey)
        собираюсь писать фронт, поэтому там можно будет его спокойно показать

DONE:   починить чаты (signalR) - скорее всего они неверно работают (отправляют сообщения не только участникам чата, а ВСЕМ участникам хаба)
        исправлено, теперь пользователи добавляются в соответствующие группы при попытке получить список сообщений из конкретного чата

DONE:   сделать нормальные связи в БД (с помощью конфигураций, а не автоматически с помощью EF Core)
        сделано, также удалена сущность Landlord и внесены соответствующие правки

DONE:   заменить почти все логи в конце методов на тип Debug - они не подходят под инфу т.к. всё равно слишком подробные, но и под Trace не подходят - не достаточно подробны.
        заменено, добавлен доп. лог в middleware по отлову ошибок, для вывода серьёзных исключений



*/

/*
 TODO: [IN PROGRESS] заменить все статусные коды на Enum StatusCodes из Microsoft.AspNetCore
 TODO: навесить `check constraint`-ы на все нужные поля сущностей в БД (продублировать валидацию с фронта)
 TODO: добавить аналогичные методы /my только для админов (чтобы они могли удалять и получать доступ к любому аккаунту)
 TODO: не совсем нравится как работает авторизация, попробовать исправить.
 TODO: заменить перебор значений из enum на метод применения фильтров в методе фильтрации имуществ
 TODO: для быстроты работы можно создать задачу на создание документа (hangfire уже подключён) и присвоение его пути в сущности в базе данных, для этого нужно будет создать состояние документа (его готовность)
 TODO: добавить ограничение на оставление отзывов от владельца имущества
 TODO: придумать что делать с отзывами на другие имущества у пользователя который стал владельцем
 TODO: превращать пользователя во владельца после добавления имущества
 TODO: проблема с удалением списков цен - они просто генерируются, а при удалении имущества список остаётся
 TODO: добавить примеры путей для контроллера например: [HttpGet("my")] // api/chat/my/ - т.е. почти полный путь рядом с контроллером
 TODO: заменить взаимодействие с файлами в сервисах contract и chatfile на взаимодействие с единым сервисом, который будет уже разбираться только с файлами
 TODO: убрать `public` в интерфейсах
 TODO: [optimization] FindAllByIdTriplet можно ускорить, там немного тяжёлая логика как будто
*/