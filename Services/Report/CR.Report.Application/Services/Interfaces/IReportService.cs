using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(ReportResponse Contact);
        Task<ReportResponse> GetReport(string Id);
        Task<IEnumerable<ReportResponse>> GetAllReport();
        Task<bool> UpdateReport(ReportResponse reportCreate);

    }
}
