namespace AirportSystem.Api.Infrastructure.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private readonly ApplicationContext _context;

    public PassengerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<PassengerEntity> AddAsync(PassengerEntity passenger, CancellationToken cancellationToken = default)
    {
        await _context.Passengers.AddAsync(passenger, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return passenger;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var passenger = await _context.Passengers.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (passenger is null)
        {
            return;
        }

        _context.Passengers.Remove(passenger);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PassengerEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Passengers.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<PassengerEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Passengers.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<DocumentEntity>> GetDocumentByPassenger(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Documents
             .Where(d => d.PassengerId == id)
             .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(PassengerEntity passenger, CancellationToken cancellationToken = default)
    {
        var findedPassenger = await _context.Passengers.SingleOrDefaultAsync(p => p.Id == passenger.Id, cancellationToken);

        if (findedPassenger is null)
        {
            return;
        }

        findedPassenger.FirstName = passenger.FirstName;
        findedPassenger.LastName = passenger.LastName;
        findedPassenger.Patronymic = passenger.Patronymic;
        findedPassenger.Document = passenger.Document;
        findedPassenger.AirTickets = passenger.AirTickets;

        await _context.SaveChangesAsync(cancellationToken);
    }
}