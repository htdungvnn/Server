using API.DataContext;
using API.Logger;
using API.Services;
using API.UOW;
using Microsoft.EntityFrameworkCore;

namespace API.BuilderRegister;

public static class AppRegister
{
    public static void AddAppServices(this IServiceCollection services,IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<ITodoService, TodoService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContextPool<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MSSQLConnection")));
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}