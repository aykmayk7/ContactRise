﻿using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using System;

namespace CR.Report.Application.Queries.SingleQuery
{
    public record ReportQuery(string Date) : IRequest<ApiResponse<ReportResponse>>;
}
