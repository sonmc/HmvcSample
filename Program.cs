

using HmvcSample.Infrastructure;
using HmvcSample.Helper;
using Microsoft.EntityFrameworkCore;
using HmvcSample.Infrastructure.Repositories;
using HmvcSample.Middleware;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ResourceManagement");
builder.Services.AddDbContext<DataContext>(x => x.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

// Add services to the container.
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();
    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    // services.AddScoped<IUserService, UserService>();
    // services.AddScoped<IUserRepository, UserRepository>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run();
