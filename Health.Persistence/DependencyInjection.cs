using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Health.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration
        configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        
        return services;
    }
}