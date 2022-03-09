using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CR.Report.Application.Queries.MultipleQuery
{
    public record ReportsQuery(Expression<Func<ReportCreate, bool>> Predicate = null) : IRequest<ApiResponse<IEnumerable<ReportResponse>>>;
}
