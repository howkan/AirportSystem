namespace AirportSystem.Api.Domain.Models.Requests;

public class CreateTicketRequest
{
    public string DeparturePoint { get; set; }

    public string DestinationPoint { get; set; }

    public DateTime DepartureDate { get; set; }

    public DateTime ArrivalDate { get; set; }

    public DateTime ServiceIssuanceDate { get; set; }

    public Guid? PassengerId { get; set; }
}