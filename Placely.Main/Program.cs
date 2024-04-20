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
