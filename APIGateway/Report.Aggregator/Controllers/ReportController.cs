using Microsoft.AspNetCore.Mvc;
using Report.Aggregator.Models;
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

        [HttpGet("GetAllReports", Name = "GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            var report = await _reportService.GetAllReports();

            return Ok(report);
        }  
        
        [HttpPut("UpdateReport", Name = "UpdateReport")]
        public async Task<IActionResult> UpdateReport(ReportCreate reportCreate)
        {
            var report = await _reportService.UpdateReport(reportCreate);

            return Ok(report);
        }

        [HttpPost("CreateReport", Name = "CreateReport")]
        public async Task<IActionResult> CreateReport(ReportCreate reportCreate)
        {
            var report = await _reportService.CreateReport(reportCreate);

            return Ok(report);
        }

    }
}