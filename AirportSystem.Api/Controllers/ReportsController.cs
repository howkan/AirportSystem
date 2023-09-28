namespace AirportSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportService _report;

    public ReportsController(IReportService report)
    {
        _report = report;
    }

    [HttpGet]
    public async Task<ActionResult<List<Report>>> GetReports(Guid passengerId, DateTime startDate, DateTime endDate)
    {
        var report = await _report.GetReports(passengerId, startDate, endDate);

        return Ok(report);
    }
}