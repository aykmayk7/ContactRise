using Report.Aggregator.Models;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportCreate> GetReport(string Id);
        Task<bool> CreateReport(ReportCreate reportCreate);
        Task<ReportCreate> GetAllReports();
        Task<bool> UpdateReport(ReportCreate reportCreate);

    }
}
