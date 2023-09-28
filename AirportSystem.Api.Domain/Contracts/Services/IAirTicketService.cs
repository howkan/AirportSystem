namespace AirportSystem.Api.Domain.Contracts.Services;

public interface IAirTicketService
{
    /// <summary>
    /// Get all AirTicket.
    /// </summary>
    public IQueryable<AirTicketEntity> GetAll();

    /// <summary>
    /// Get AirTicket by Id.
    /// </summary>
    public Task<AirTicketEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new AirTicket.
    /// </summary>
    public Task<AirTicketEntity> AddAsync(AirTicketEntity ticket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update AirTicket.
    /// </summary>
    public Task UpdateAsync(AirTicketEntity ticket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete AirTicket.
    /// </summary>
    public Task  DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get full ticket info.
    /// </summary>
    public Task<AirTicketEntity> GetTicketInfo(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get passenger by ticket.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task<IEnumerable<PassengerEntity>> GetPassengersByTicket(Guid id, CancellationToken cancellationToken = default);
}
