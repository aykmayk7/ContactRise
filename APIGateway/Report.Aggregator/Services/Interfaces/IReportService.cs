using Report.Aggregator.Models;
using System;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportCreate> GetReport(string date);
    }
}
