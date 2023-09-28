namespace AirportSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirTicketController : ControllerBase
{
    private readonly IAirTicketService _service;

    public AirTicketController(IAirTicketService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<AirTicketEntity>>> GetTicketsAsync()
    {
        var tickets = await _service.GetAll().ToListAsync();

        return Ok(tickets);
    }

    [HttpGet("{id}/Passenger")]
    public async Task<ActionResult<IEnumerable<PassengerEntity>>> GetPassengersByTicket(Guid id)
    {
        var passengers = await _service.GetPassengersByTicket(id);

        if (passengers is null)
        {
            return NotFound();
        }

        return Ok(passengers);
    }

    [HttpGet("{id}/Info")]
    public async Task<ActionResult<FindFullInfoByTicketResponse>> GetFullTicketInfo(Guid id)
    {
        var ticketFullInfo = await _service.GetTicketInfo(id);

        if (ticketFullInfo is null)
        {
            return NotFound();
        }

        return Ok(new FindFullInfoByTicketResponse(ticketFullInfo));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AirTicketEntity>> GetTicketByIdAsync(Guid id)
    {
        var ticket = await _service.GetByIdAsync(id);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var ticket = await _service.GetByIdAsync(id);

        if (ticket is null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(ticket.Id);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(CreateTicketRequest request)
    {
        var ticketFromQuery = new AirTicketEntity()
        {
            ArrivalDate = request.ArrivalDate,
            DepartureDate = request.DepartureDate,
            DeparturePoint = request.DestinationPoint,
            DestinationPoint = request.DestinationPoint,
            ServiceIssuanceDate = request.ServiceIssuanceDate,
            PassengerId = request.PassengerId
        };

        var createdTicked = await _service.AddAsync(ticketFromQuery);

        return Ok(new CreateTicketResponse() { Id = createdTicked.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(Guid id, UpdateTicketRequest request)
    {
        var ticketFromQuery = new AirTicketEntity()
        {
            Id = id,
            ArrivalDate = request.ArrivalDate,
            DepartureDate = request.DepartureDate,
            DeparturePoint = request.DeparturePoint,
            DestinationPoint = request.DestinationPoint,
            ServiceIssuanceDate = request.ServiceIssuanceDate,
            PassengerId = request.PassengerId
        };

        var passenger = await _service.GetTicketInfo(ticketFromQuery.Id);

        if (passenger is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(ticketFromQuery);

        return Ok(); 
    }
}