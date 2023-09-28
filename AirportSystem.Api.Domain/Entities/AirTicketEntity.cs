namespace AirportSystem.Api.Domain.Entities;

public class AirTicketEntity
{
    public Guid Id { get; set; }

    public string DeparturePoint { get; set; }

    public string DestinationPoint { get; set; }

    public DateTime DepartureDate { get; set; }
   
    public DateTime ArrivalDate { get; set; }

    public DateTime ServiceIssuanceDate { get; set; }

    public Guid? PassengerId { get; set; }

    public PassengerEntity? Passenger { get; set; }
}