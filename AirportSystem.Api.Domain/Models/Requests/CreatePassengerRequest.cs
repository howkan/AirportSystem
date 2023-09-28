namespace AirportSystem.Api.Domain.Models.Requests;

public class CreatePassengerRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }
}
