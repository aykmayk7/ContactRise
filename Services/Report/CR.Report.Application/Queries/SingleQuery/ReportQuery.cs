using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Queries.SingleQuery
{
    public record ReportQuery(string date, ReportStatusEnum reportStatusEnum) : IRequest<ApiResponse<ReportResponse>>;
}
