using CR.Report.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(ReportResponse reportCreate);
        Task<ReportResponse> GetReport(string Id);
        Task<ReportInfoResponse> GetReportInfo();
        Task<IEnumerable<ReportResponse>> GetAllReport();
        Task<bool> UpdateReport(ReportResponse reportCreate);

    }
}
