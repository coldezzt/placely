using Placely.Main.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddDbContext(builder.Configuration);
builder.AddDependencies();

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.Run();
