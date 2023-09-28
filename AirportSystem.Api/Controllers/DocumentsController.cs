namespace AirportSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _service;

    public DocumentsController(IDocumentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentEntity>>> GetAllAsync()
    {
        var tickets = await _service.GetAllAsync();

        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentEntity>> GetByIdAsync(Guid id)
    {
        var document = await _service.GetByIdAsync(id);

        if (document is null)
        {
            return NotFound();
        }

        return Ok(document);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<DocumentEntity>> DeleteAsync(Guid id)
    {
        var document = await _service.GetByIdAsync(id);

        if (document is null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(document.Id);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDocumentRequest request)
    {
        var documentFromQuery = new DocumentEntity()
        {
            Type = request.Type
        };

        var createdDocument = await _service.AddAsync(documentFromQuery);

        return Ok(new CreateDocumentResponse() { Id = createdDocument.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateDocumentRequest request)
    {
        var documentFromQuery = new DocumentEntity()
        {
            Id = id,
            Type = request.Type,
            PassengerId = request.PassengerId
        };

        var document = await _service.GetByIdAsync(documentFromQuery.Id);

        if (document is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(documentFromQuery);

        return Ok();
    }
}