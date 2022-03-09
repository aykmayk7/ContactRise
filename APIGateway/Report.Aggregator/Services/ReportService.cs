using CR.Core.Responses;
using Report.Aggregator.Extensions;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Report.Aggregator.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _client;
        public ReportService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<ReportCreate> GetReport(string date)
        {
            var response = await _client.GetAsync($"/api/v1/Report/GetReportInfos?date={ date }");

            var report = await response.ReadContentAs<ApiResponse<ReportCreate>>();

            return report.Data;
        }
    }
}
