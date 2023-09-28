namespace AirportSystem.Api.Domain.Contracts.Repositories;

public interface IDocumentRepository
{
    /// <summary>
    /// Get All documents.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public Task<IEnumerable<DocumentEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get document by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task<DocumentEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new document. 
    /// </summary>
    /// <param name="document"></param>
    /// <param name="cancellationToken"></param>
    public Task<DocumentEntity> AddAsync(DocumentEntity document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update document by Id,
    /// </summary>
    /// <param name="document"></param>
    /// <param name="cancellationToken"></param>
    public Task UpdateAsync(DocumentEntity document, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete document by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
