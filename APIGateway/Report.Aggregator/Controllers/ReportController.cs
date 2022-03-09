using Microsoft.AspNetCore.Mvc;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));

        }


        [HttpGet("GetReport", Name = "GetReport")]
        public async Task<IActionResult> GetReport(string date)
        {
            var sellerProducts = await _reportService.GetReport(date);

            return Ok(sellerProducts);
        }
    }
}