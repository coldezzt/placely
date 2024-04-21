using Hangfire;
using Placely.Main.Controllers.Hubs;
using Placely.Main.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

// Настройка сервисов. Всё что возвращает IServiceCollection
builder.Services
    .AddRouting(opt => opt.LowercaseUrls = true)
    .AddRepositories()
    .AddServices()
    .AddValidators()
    .AddDbContext(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddConfiguredSwaggerGen()
    .AddConfiguredAutoMapper()
    .AddConfiguredHangfire(builder.Configuration)
    .AddConfiguredJwtAuth(builder.Configuration);

// Настройка сервисов. Всё что НЕ возвращает IServiceCollection
builder.Services.AddControllers();
builder.Services.AddSignalR();

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application
        .UseSwagger()
        .UseSwaggerUI();
}

// Различные using-и
application
    .UseAuthentication()
    .UseAuthorization()
    .UseHttpsRedirection()
    .UseHangfireDashboard();

// Маппинг
application.MapControllers();
application.MapHub<ChatHub>("api/hubs/chat");

application.Run();

// TODO: вынести "api" из каждого контроллера сюда.
// TODO: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа)
// TODO: пробежаться по роутам и навесить на параметры внутри ограничения на тип
// TODO: добавить метод добавления в избранные property