using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using System;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Commands.Create
{
    public class ReportCreate : IRequest<ApiResponse<ReportResponse>>
    {
 
        public Guid Id { get; set; }

        public DateTime ReportDate { get; set; }

        public string ReportTarget { get; set; }

        public ReportStatusEnum ReportStatus { get; set; }

    }
}
