namespace AirportSystem.Api.Domain.Contracts.Services;

public interface IReportService
{
    public Task<IEnumerable<Report>> GetReports(Guid passengerId, DateTime startDate, 
        DateTime endDate, CancellationToken cancellationToken = default);
}