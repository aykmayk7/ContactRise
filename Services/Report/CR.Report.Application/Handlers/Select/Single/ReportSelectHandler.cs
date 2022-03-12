using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Queries.SingleQuery;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Select.Single
{
    public class ReportSelectHandler : IRequestHandler<ReportQuery, ApiResponse<ReportResponse>>
    {

        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        public ReportSelectHandler(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReportResponse>> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            var model = await _reportService.GetReport(request.Id);

            var response = _mapper.Map<ReportResponse>(model);

            return new SuccessApiResponse<ReportResponse>(response);
        }
    }
}