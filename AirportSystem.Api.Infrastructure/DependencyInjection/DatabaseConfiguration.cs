namespace AirportSystem.Api.Infrastructure.DependencyInjection;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<ApplicationContext>();

        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(
            connectionString: configuration.GetConnectionString(name: "DbConnection")));
    }
}