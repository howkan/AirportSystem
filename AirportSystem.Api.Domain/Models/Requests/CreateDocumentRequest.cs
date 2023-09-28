namespace AirportSystem.Api.Domain.Models.Requests;

public class CreateDocumentRequest
{
    public string Type { get; set; }

    public Guid? PassengerId { get; set; }
}
