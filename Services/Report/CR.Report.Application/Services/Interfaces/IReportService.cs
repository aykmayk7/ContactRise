using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportResponse> CreateReport(ReportCreate Contact);
        Task<IEnumerable<ReportResponse>> GetReport(string date, ReportStatusEnum reportStatusEnum);
        Task<IEnumerable<ReportResponse>> GetAllReport();

    }
}
