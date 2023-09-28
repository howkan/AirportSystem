namespace AirportSystem.Api.Application.Services;

public class ReportService : IReportService
{
    private readonly IAirTicketRepository _repository;

    public ReportService(IAirTicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Report>> GetReports(Guid passengerId,
        DateTime startDate, DateTime endDate, 
        CancellationToken cancellationToken = default)
    {
        var tickets = _repository.GetAll();

        var report = tickets
            .Where(ticket =>
                ticket.ServiceIssuanceDate >= startDate &&
                ticket.ServiceIssuanceDate <= endDate)
            .Select(ticket => new Report
            {
                Id = ticket.Id,
                ServiceIssuanceDate = ticket.ServiceIssuanceDate,
                DepartureDate = ticket.DepartureDate,
                DeparturePoint = ticket.DeparturePoint,
                DestinationPoint = ticket.DestinationPoint,
                ServiceProvided = ticket.PassengerId.HasValue 
            });

        return await report.ToListAsync(cancellationToken);
    }
}