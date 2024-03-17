using BL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("application.json", optional: true, reloadOnChange: true);

builder.Services.AddDbContext(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
