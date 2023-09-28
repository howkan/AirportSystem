namespace AirportSystem.Api.Application.Services;

public class PassengerService : IPassengerService
{
    private readonly IPassengerRepository _repository;

    public PassengerService(IPassengerRepository repository)
    {
        _repository = repository;
    }

    public async Task<PassengerEntity?> AddAsync(PassengerEntity passenger,
        CancellationToken cancellationToken = default) =>
       await _repository.AddAsync(passenger, cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(id, cancellationToken);

    public async Task<IEnumerable<PassengerEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _repository.GetAllAsync(cancellationToken);

    public async Task<PassengerEntity?> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.FirstOrDefaultAsync(id, cancellationToken);

    public async Task<IEnumerable<DocumentEntity>> GetDocumentByPassenger(Guid id,
        CancellationToken cancellationToken = default) =>
        await _repository.GetDocumentByPassenger(id, cancellationToken);

    public async Task UpdateAsync(PassengerEntity passenger,
        CancellationToken cancellationToken = default) =>
        await _repository.UpdateAsync(passenger, cancellationToken);
}
