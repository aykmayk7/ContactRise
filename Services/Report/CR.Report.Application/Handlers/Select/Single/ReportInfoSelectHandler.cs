using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Queries.SingleQuery;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Select.Single
{
    public class ReportInfoSelectHandler : IRequestHandler<ReportInfoQuery, ApiResponse<ReportInfoCreate>>
    {

        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        public ReportInfoSelectHandler(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReportInfoCreate>> Handle(ReportInfoQuery request, CancellationToken cancellationToken)
        {
            var model = await _reportService.GetReportInfo(request.Date);

            var response = _mapper.Map<ReportInfoCreate>(model);

            return new SuccessApiResponse<ReportInfoCreate>(response);
        }
    }
}