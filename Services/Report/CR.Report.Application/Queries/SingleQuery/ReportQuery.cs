using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using MediatR;
using System;
using System.Linq.Expressions;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Queries.SingleQuery
{
    public record ReportQuery(DateTime date, ReportStatusEnum reportStatusEnum) : IRequest<ApiResponse<ReportResponse>>;
}
