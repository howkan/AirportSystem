namespace AirportSystem.Api.Domain.Contracts.Services
{
    public interface IDocumentService
    {
        /// <summary>
        /// Get all Documents.
        /// </summary>
        public Task<IEnumerable<DocumentEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Document by ID.
        /// </summary>
        public Task<DocumentEntity?> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add new Document.
        /// </summary>
        public Task<DocumentEntity?> AddAsync(DocumentEntity document,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update Document.
        /// </summary>
        public Task UpdateAsync(DocumentEntity document,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Document.
        /// </summary>
        public Task DeleteAsync(Guid id,
            CancellationToken cancellationToken = default);

    }
}
