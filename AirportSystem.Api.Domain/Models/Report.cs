namespace AirportSystem.Api.Domain.Models;

public class Report
{
    public Guid Id { get; set; }

    public DateTime ServiceIssuanceDate { get; set; }

    public DateTime DepartureDate { get; set; }

    public string DeparturePoint { get; set; }

    public string DestinationPoint { get; set; }

    public bool ServiceProvided { get; set; }
}