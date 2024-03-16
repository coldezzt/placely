using BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(
        "Username=postgres;Password=hellohell;Host=localhost;Port=5433;Database=Placely;Pooling=true;");
    optionsBuilder.UseSnakeCaseNamingConvention();
});

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
