using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using MediatR;
using System;
using System.Linq.Expressions;

namespace CR.Report.Application.Queries.SingleQuery
{
    public record ReportInfoQuery(Expression<Func<ReportInfoCreate, bool>> Predicate = null) : IRequest<ApiResponse<ReportInfoResponse>>;
}
