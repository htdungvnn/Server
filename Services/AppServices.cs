using API.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public static class AppServices
{
    public static void AddAppServices(this IServiceCollection services,IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("ConStr")));
    }
}