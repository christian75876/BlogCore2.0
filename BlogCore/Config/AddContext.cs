using BlogCore.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogCore.Config;

public static class AddContext
{
    public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
            ));
        return services;
    }
}