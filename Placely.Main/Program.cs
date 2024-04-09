using Placely.Main.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services
    .AddRepositories()
    .AddServices()
    .AddDbContext(builder.Configuration)
    .AddRouting(opt => opt.LowercaseUrls = true)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application
        .UseSwagger()
        .UseSwaggerUI();
}

application
    .UseStaticFiles()
    .UseHttpsRedirection();

application.MapControllers();

application.Run();
