using CR.Report.Application.Commands.Create;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Queries.SingleQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Report.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediatr;
        public ReportController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            return result.Success ? Success(result) : BadRequest(result);
        }


        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            var query = new ReportsQuery();

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpGet("GetReportInfos")]
        public async Task<IActionResult> GetReport(DateTime date, ReportStatusEnum reportStatusEnum)
        {
            var query = new ReportQuery(date, reportStatusEnum);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

    }
}
