using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportResponse> CreateReport(ReportCreate Contact);
        Task<ReportCreate> GetReport(string date);
        Task<IEnumerable<ReportResponse>> GetAllReport();

    }
}
