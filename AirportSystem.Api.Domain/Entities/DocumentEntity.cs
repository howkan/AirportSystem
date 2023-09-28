namespace AirportSystem.Api.Domain.Entities;

public class DocumentEntity
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public Guid? PassengerId { get; set; }

    public PassengerEntity? Passenger { get; set; }
}