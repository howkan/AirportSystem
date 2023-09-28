namespace AirportSystem.Api.Domain.Entities;

public class PassengerEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }
    
    public DocumentEntity? Document { get; set; }

    public IEnumerable<AirTicketEntity>? AirTickets { get; set; }
}