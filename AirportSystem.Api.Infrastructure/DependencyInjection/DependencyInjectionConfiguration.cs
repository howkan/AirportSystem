namespace AirportSystem.Api.Infrastructure.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAirTicketRepository, AirTicketRepository>();
        
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        services.AddScoped<IPassengerRepository, PassengerRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAirTicketService, AirTicketService>();

        services.AddScoped<IDocumentService, DocumentService>();

        services.AddScoped<IPassengerService, PassengerService>();

        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}