using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using MediatR;
using System;

namespace CR.Report.Application.Queries.SingleQuery
{

    public record ReportInfoQuery(string Date) : IRequest<ApiResponse<ReportInfoCreate>>;


}
