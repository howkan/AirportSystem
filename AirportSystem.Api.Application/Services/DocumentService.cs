namespace AirportSystem.Api.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _repository;

    public DocumentService(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public async Task<DocumentEntity?> AddAsync(DocumentEntity document,
        CancellationToken cancellationToken = default) =>
         await _repository.AddAsync(document, cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
       await _repository.DeleteAsync(id, cancellationToken);

    public async Task<IEnumerable<DocumentEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
       await _repository.GetAllAsync(cancellationToken);

    public async Task<DocumentEntity?> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken = default) =>
       await _repository.FirstOrDefaultAsync(id, cancellationToken);

    public async Task UpdateAsync(DocumentEntity document, 
        CancellationToken cancellationToken = default) =>
        await _repository.UpdateAsync(document, cancellationToken);
}
