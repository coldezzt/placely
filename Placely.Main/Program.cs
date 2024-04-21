using Placely.Main.Controllers.Hubs;
using Placely.Main.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddSignalR();

builder.Services
    .AddRouting(opt => opt.LowercaseUrls = true)
    .AddRepositories()
    .AddServices()
    .AddValidators()
    .AddDbContext(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddConfiguredSwaggerGen()
    .AddConfiguredAutoMapper()
    .AddConfiguredJwtAuth(builder.Configuration)
    .AddControllers();

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application
        .UseSwagger()
        .UseSwaggerUI();
}

application
    .UseAuthentication()
    .UseAuthorization()
    .UseHttpsRedirection();

application.MapControllers();
application.MapHub<ChatHub>("api/hubs/chat");

application.Run();

// TODO: вынести "api" из каждого контроллера сюда.
// TODO: написать маппер под ошибки валидатора (там есть ненужная для фронта инфа)
// TODO: пробежаться по роутам и навесить на параметры внутри ограничения на тип
// TODO: добавить метод добавления в избранные property