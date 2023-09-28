namespace AirportSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PassengersController : ControllerBase
{
    private readonly IPassengerService _service;

    public PassengersController(IPassengerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PassengerEntity>>> GetAllAsync()
    {
        var passengers = await _service.GetAllAsync();

        return Ok(passengers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PassengerEntity>> GetByIdAsync(Guid id)
    {
        var passenger = await _service.GetByIdAsync(id);

        if (passenger is null)
        {
            return NotFound();
        }

        return Ok(passenger);
    }

    [HttpGet("{id}/Document")]
    public async Task<ActionResult<DocumentEntity>> GetDocumentByPassengerIdAsync(Guid id)
    {
        var documents = await _service.GetDocumentByPassenger(id);

        if (documents is null)
        {
            return NotFound();
        }

        return Ok(documents);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var passenger = await _service.GetByIdAsync(id);

        if (passenger is null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(passenger.Id);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePassengerRequest request)
    {
        var passengerFromQuery = new PassengerEntity()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic
        };

        var createdPassenger = await _service.AddAsync(passengerFromQuery);

        return Ok(new CreatePassengerResponse() { Id = createdPassenger.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdatePassengerRequest request)
    {
        var passengerFromQuery = new PassengerEntity()
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic
        };

        var passenger = await _service.GetByIdAsync(passengerFromQuery.Id);

        if (passenger is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(passengerFromQuery);

        return Ok();
    }
}