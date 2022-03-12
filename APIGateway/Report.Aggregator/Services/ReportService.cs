  
using CR.Core.Responses;
using Newtonsoft.Json;
using Report.Aggregator.Extensions;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<ReportCreate> GetReport(string Id)
        {
            var response = await _client.GetAsync($"/api/v1/Report/GetReport?id={ Id }");

            var report = await response.ReadContentAs<ApiResponse<ReportCreate>>();

            return report.Data;
        }

        public async Task<IEnumerable<ReportCreate>> GetAllReports()
        {
            var response = await _client.GetAsync($"/api/v1/Report/GetAllReports");

            var report = await response.ReadContentAs<ApiResponse<ReportCreate>>();

            return (IEnumerable<ReportCreate>)report.Data;
        }

        public async Task<bool> UpdateReport(ReportCreate reportCreate)
        {
            string json = JsonConvert.SerializeObject(reportCreate);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/Report/ReportUpdate/", httpContent);

            var report = await response.ReadContentAs<ApiResponse<ReportCreate>>();

            return report.Success;
        }

        public async Task<bool> CreateReport(ReportCreate reportCreate)
        {
            string json = JsonConvert.SerializeObject(reportCreate.ReportName);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/Report/CreateReport/", httpContent);

            var report = await response.ReadContentAs<ApiResponse<ReportCreate>>();

            return report.Success;
        }

        public async Task<ReportInfoCreate> GetReportInfo()
        {
            var response = await _client.GetAsync($"/api/v1/Report/GetReportInfo");

            var report = await response.ReadContentAs<ApiResponse<ReportInfoCreate>>();

            return report.Data;
        }
    }
}
