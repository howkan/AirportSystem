namespace AirportSystem.Api.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly ApplicationContext _context;

    public DocumentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<DocumentEntity> AddAsync(DocumentEntity document, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(document, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return document;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var document = await _context.Documents.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (document is null)
        {
            return;
        }

        _context.Documents.Remove(document);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<DocumentEntity?> FirstOrDefaultAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Documents.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<DocumentEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Documents.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(DocumentEntity document, CancellationToken cancellationToken = default)
    {
        var findedDocument = await _context.Documents.SingleOrDefaultAsync(p => p.Id == document.Id, cancellationToken);

        if (findedDocument is null)
        {
            return;
        }

        findedDocument.Type = document.Type;
        findedDocument.Passenger = document.Passenger;
        findedDocument.PassengerId = document.PassengerId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}