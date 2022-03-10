using CR.Report.Application.Commands.Create;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Queries.SingleQuery;
using EventBus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CR.Report.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediatr;
        RabbitMQPublish<ReportCreate> MQ = new RabbitMQPublish<ReportCreate>();

        public ReportController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            MQ.SendMessage(command);

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

        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport(DateTime date)
        {
            var query = new ReportQuery(date);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

    }
}
