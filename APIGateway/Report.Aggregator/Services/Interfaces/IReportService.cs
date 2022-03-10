using Report.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportCreate> GetReport(string date);

        Task<IEnumerable<ReportInfoCreate>> GetReportInfo(string date);

    }
}
