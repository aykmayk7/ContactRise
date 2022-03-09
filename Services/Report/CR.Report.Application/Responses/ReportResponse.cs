using System;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Responses
{
    public class ReportResponse : BaseResponse
    {
        public DateTime ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }

    }
}
