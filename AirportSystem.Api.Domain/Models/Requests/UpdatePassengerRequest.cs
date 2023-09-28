namespace AirportSystem.Api.Domain.Models.Requests;

public class UpdatePassengerRequest
{
    public Guid Id {  get; set; }   

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }
}
