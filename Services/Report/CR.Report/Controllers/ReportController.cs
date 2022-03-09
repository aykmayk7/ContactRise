using CR.Report.Application.Commands.Create;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Queries.SingleQuery;
using MassTransit;
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
        private readonly IPublishEndpoint _publishEndpoint;
        public ReportController(IMediator mediatr, IPublishEndpoint publishEndpoint)
        {
            _mediatr = mediatr;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            await _publishEndpoint.Publish<ReportCreate>(command);

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
        public async Task<IActionResult> GetReport(string date)
        {
            var query = new ReportQuery(date);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

    }
}
