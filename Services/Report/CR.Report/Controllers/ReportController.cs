using CR.Report.Application.Commands.Create;
using CR.Report.Application.Commands.Update;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Queries.SingleQuery;
using EventBus.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CR.Report.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediatr;
        private readonly IRabbitMQPublish<ReportCreate> _rabbitMQPublish;

        public ReportController(IMediator mediatr, IRabbitMQPublish<ReportCreate> rabbitMQPublish)
        {
            _mediatr = mediatr;
            _rabbitMQPublish = rabbitMQPublish;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            await _rabbitMQPublish.SendMessage(command);

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
        public async Task<IActionResult> GetReport(string date)
        {
            var query = new ReportQuery(date);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpPost("CreateReportInfo")]
        public async Task<IActionResult> CreateReportInfo([FromBody] ReportInfoCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            return result.Success ? Success(result) : BadRequest(result);

        }


        [HttpGet("GetReportInfo")]
        public async Task<IActionResult> GetReportInfo(string date)
        {
            var query = new ReportInfoQuery(date);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpPut("ReportUpdate")]
        public async Task<IActionResult> ReportUpdate([FromBody] ReportUpdate reportCreate)
        {
            var result = await _mediatr.Send(reportCreate);

            if (result == null) NotFound(result);
 
            return result.Success ? Success(result) : BadRequest(result);
        }
    }
}
