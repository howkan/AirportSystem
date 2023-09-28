namespace AirportSystem.Api.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public DbSet<AirTicketEntity> AirTickets { get; set; }

    public DbSet<DocumentEntity> Documents { get; set; }

    public DbSet<PassengerEntity> Passengers { get; set; } 

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}