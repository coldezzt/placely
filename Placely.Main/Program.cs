using Placely.Data.Configurations.Mapper;
using Placely.Main.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.ConfigureJwtAuth(builder.Configuration);

builder.Services
    .AddRepositories()
    .AddServices()
    .AddDbContext(builder.Configuration)
    .AddRouting(opt => opt.LowercaseUrls = true)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddAutoMapper(cfg =>
    {
        cfg.AddProfiles(new[]
        {
            new ContractMapperProfile()
        });
    });

builder.Services.AddControllers();

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

application.Run();
