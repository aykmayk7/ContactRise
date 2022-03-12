using CR.Report.Application.Commands.Create;
using CR.Report.Application.Commands.Update;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Queries.SingleQuery;
using CR.Report.Application.Responses;
using DotNetCore.CAP;
using EventBus;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CR.Report.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediatr;
        private readonly ICapPublisher _capPublisher;
        private readonly IPublishEndpoint _publishEndpoint;


        public ReportController(IMediator mediatr, IPublishEndpoint publishEndpoint, ICapPublisher capPublisher)
        {
            _mediatr = mediatr;
            _capPublisher = capPublisher;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            result.AuditJson = JsonConvert.SerializeObject(result);

            if (result.Success && !string.IsNullOrEmpty(result.AuditJson))
                await _capPublisher.PublishAsync(EventBusConstants.ReportQueue, result.AuditJson);
            await _publishEndpoint.Publish<ReportResponse>(result);

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

        [HttpPut("UpdateReport")]
        public async Task<IActionResult> UpdateReport([FromBody] ReportUpdate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            return result.Success ? Success(result) : BadRequest(result);

        }


        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport(string Id)
        {
            var query = new ReportQuery(Id);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }
    }
}
