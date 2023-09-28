namespace AirportSystem.Api.Application.Services;

public class AirTicketService : IAirTicketService
{
    private readonly IAirTicketRepository _repository;

    public AirTicketService(IAirTicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<AirTicketEntity> AddAsync(AirTicketEntity ticket,
        CancellationToken cancellationToken = default) =>
        await _repository.AddAsync(ticket, cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(id, cancellationToken);

    public IQueryable<AirTicketEntity> GetAll() => _repository.GetAll();

    public async Task<AirTicketEntity?> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken = default) => 
        await _repository.FirstOrDefaultAsync(id, cancellationToken);

    public async Task<AirTicketEntity> GetTicketInfo(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.GetFullTicketInfo(id, cancellationToken);

    public async Task<IEnumerable<PassengerEntity>> GetPassengersByTicket(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.GetPassengersByTicket(id, cancellationToken);

    public async Task UpdateAsync(AirTicketEntity ticket,
        CancellationToken cancellationToken = default) =>
        await _repository.UpdateAsync(ticket, cancellationToken);
}