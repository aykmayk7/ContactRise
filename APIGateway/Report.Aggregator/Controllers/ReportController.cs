using Microsoft.AspNetCore.Mvc;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.Aggregator.Controllers
{
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
            var report = await _reportService.GetReport(date);

            return Ok(report);
        }

        [HttpGet("GetReportInfo", Name = "GetReportInfo")]
        public async Task<IActionResult> GetReportInfo(string date)
        {
            var report = await _reportService.GetReportInfo(date);

            return Ok(report);
        }

    }
}