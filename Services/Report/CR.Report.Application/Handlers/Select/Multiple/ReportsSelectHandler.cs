using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Queries.MultipleQuery;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Select.Multiple
{
    public class ReportsSelectHandler : IRequestHandler<ReportsQuery, ApiResponse<IEnumerable<ReportResponse>>>
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        public ReportsSelectHandler(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ReportResponse>>> Handle(ReportsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ReportResponse> data = await _reportService.GetAllReport();

            var response = _mapper.Map<IEnumerable<ReportResponse>>(data);

            return new SuccessApiResponse<IEnumerable<ReportResponse>>(response);
        }
    }
}