namespace AirportSystem.Api.Domain.Contracts.Repositories;

public interface IPassengerRepository
{
    /// <summary>
    /// Get All passengers.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public Task<IEnumerable<PassengerEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get passenger by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task<PassengerEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new passenger. 
    /// </summary>
    /// <param name="passenger"></param>
    /// <param name="cancellationToken"></param>
    public Task<PassengerEntity> AddAsync(PassengerEntity passenger, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update passenger by Id.
    /// </summary>
    /// <param name="passenger"></param>
    /// <param name="cancellationToken"></param>
    public Task UpdateAsync(PassengerEntity passenger, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete passenger by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Read list documents by passenger.
    /// </summary>
    /// <param name="id"></param>
    public Task<IEnumerable<DocumentEntity>> GetDocumentByPassenger(Guid id, CancellationToken cancellationToken = default);
}