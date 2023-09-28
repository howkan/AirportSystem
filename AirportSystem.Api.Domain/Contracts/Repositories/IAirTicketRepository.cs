namespace AirportSystem.Api.Domain.Contracts.Repositories;

public interface IAirTicketRepository
{
    /// <summary>
    /// Get All tickets.
    /// </summary>
    public IQueryable<AirTicketEntity> GetAll();

    /// <summary>
    /// Get <see cref="AirTicketEntity"/> by <see cref="AirTicketEntity.Id"/>.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task<AirTicketEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new ticket. 
    /// </summary>
    /// <param name="airTicket"></param>
    /// <param name="cancellationToken"></param>
    public Task<AirTicketEntity> AddAsync(AirTicketEntity airTicket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update ticket by Id,
    /// </summary>
    /// <param name="AirTicket"></param>
    /// <param name="cancellationToken"></param>
    public Task UpdateAsync(AirTicketEntity AirTicket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete ticket by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Read full info by ticket.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public Task<AirTicketEntity?> GetFullTicketInfo(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Read list passenger by Id ticket.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task<IEnumerable<PassengerEntity>> GetPassengersByTicket(Guid id, CancellationToken cancellationToken = default);

}