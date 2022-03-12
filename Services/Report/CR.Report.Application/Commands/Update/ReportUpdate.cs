using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using System;

namespace CR.Report.Application.Commands.Update
{
    public record ReportUpdate(Guid Id) : IRequest<ApiResponse<ReportResponse>>;
}
