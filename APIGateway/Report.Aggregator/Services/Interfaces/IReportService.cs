using Report.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportCreate> GetReport(string Id);
        Task<bool> CreateReport(ReportCreate reportCreate);
        Task<IEnumerable<ReportCreate>> GetAllReports();
        Task<bool> UpdateReport(ReportCreate reportCreate);
        Task<ReportInfoCreate> GetReportInfo();
    }
}