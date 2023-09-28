namespace AirportSystem.Api.Domain.Contracts.Services
{
    public interface IPassengerService
    {
        /// <summary>
        /// Get all Passengers.
        /// </summary>
        public Task<IEnumerable<PassengerEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Passenger by ID.
        /// </summary>
        public Task<PassengerEntity?> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add new Passenger.
        /// </summary>
        public Task<PassengerEntity?> AddAsync(PassengerEntity passenger,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update Passenger.
        /// </summary>
        public Task UpdateAsync(PassengerEntity passenger,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Passenger.
        /// </summary>
        public Task DeleteAsync(Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get documents by passenger.
        /// </summary>
        public Task<IEnumerable<DocumentEntity>> GetDocumentByPassenger(Guid id,
            CancellationToken cancellationToken = default);
    }
}
