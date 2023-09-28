namespace AirportSystem.Api.Domain.Models.Requests;

public class UpdateDocumentRequest
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public Guid? PassengerId { get; set; }
}
