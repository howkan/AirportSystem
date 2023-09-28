namespace AirportSystem.Api.Infrastructure.Repositories;

public class AirTicketRepository : IAirTicketRepository
{
    private readonly ApplicationContext _context;

    public AirTicketRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<AirTicketEntity> AddAsync(AirTicketEntity airTicket, CancellationToken cancellationToken = default)
    {
        await _context.AirTickets.AddAsync(airTicket, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return airTicket;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticket = await _context.AirTickets.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (ticket is null)
        {
            return;
        }

        _context.AirTickets.Remove(ticket);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<AirTicketEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.AirTickets.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public IQueryable<AirTicketEntity> GetAll()
    {
        return _context.AirTickets;
    }

    public async Task<AirTicketEntity?> GetFullTicketInfo(Guid id, CancellationToken cancellationToken = default)
    {
        var ticketInfo = await _context.AirTickets
            .Include(t => t.Passenger)
            .ThenInclude(p => p.Document)
            .SingleOrDefaultAsync(t => t.Id == id, cancellationToken);

        return ticketInfo;
    }

    public async Task<IEnumerable<PassengerEntity>> GetPassengersByTicket(Guid id, CancellationToken cancellationToken = default)
    {
        var passengers = await _context.Passengers
            .Where(p => p.AirTickets != null && p.AirTickets.Any(t => t.Id == id))
            .ToListAsync(cancellationToken);

        return passengers;
    }

    public async Task UpdateAsync(AirTicketEntity airTicket, CancellationToken cancellationToken = default)
    {
        var findedTicket = await _context.AirTickets.SingleOrDefaultAsync(p => p.Id == airTicket.Id, cancellationToken);

        if (findedTicket is null)
        {
            return;
        }

        findedTicket.DeparturePoint = airTicket.DeparturePoint;
        findedTicket.DestinationPoint = airTicket.DestinationPoint;
        findedTicket.DepartureDate = airTicket.DepartureDate;
        findedTicket.ArrivalDate = airTicket.ArrivalDate;
        findedTicket.ServiceIssuanceDate = airTicket.ServiceIssuanceDate;
        findedTicket.PassengerId = airTicket.PassengerId;
        findedTicket.Passenger = airTicket.Passenger;

        await _context.SaveChangesAsync(cancellationToken);
    }
}