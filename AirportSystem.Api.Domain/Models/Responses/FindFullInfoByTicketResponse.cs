namespace AirportSystem.Api.Domain.Models.Responses;

public class FindFullInfoByTicketResponse
{
    public FindFullInfoByTicketResponse(AirTicketEntity ticket)
    {
        Id = ticket.Id;
        DeparturePoint = ticket.DeparturePoint;
        DestinationPoint = ticket.DestinationPoint;
        DepartureDate = ticket.DepartureDate;
        ArrivalDate = ticket.ArrivalDate;
        ServiceIssuanceDate = ticket.ServiceIssuanceDate;
        PassengerId = ticket.PassengerId;
        FirstName = ticket.Passenger.FirstName;
        LastName = ticket.Passenger.LastName;
        Patronymic = ticket.Passenger.Patronymic;
        DocumentId = ticket.Passenger.Document.Id;
        Type = ticket.Passenger.Document.Type;
    }

    public Guid Id { get; set; }

    public string DeparturePoint { get; set; }

    public string DestinationPoint { get; set; }

    public DateTime DepartureDate { get; set; }

    public DateTime ArrivalDate { get; set; }

    public DateTime ServiceIssuanceDate { get; set; }

    public Guid? PassengerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public Guid DocumentId { get; set; }

    public string Type { get; set; }
}
