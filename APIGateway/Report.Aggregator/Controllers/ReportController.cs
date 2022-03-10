using Microsoft.AspNetCore.Mvc;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly IContactService _contactService;

        public ReportController(IReportService reportService, IContactService contactService)
        {
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }


        [HttpGet("CreateContact", Name = "CreateContact")]
        public async Task<IActionResult> GetReport(string date)
        {
            var report = await _contactService.Create(date);

            return Ok(report);
        }

    }
}