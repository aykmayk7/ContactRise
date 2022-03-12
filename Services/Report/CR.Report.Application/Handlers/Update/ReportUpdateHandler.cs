using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Commands.Update;
using CR.Report.Application.Helpers;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Update
{
    public class ReportUpdateHandler : IRequestHandler<ReportUpdate, ApiResponse<ReportResponse>>
    {
        private readonly IReportService _ReportService;
        private readonly IMapper _mapper;
        public ReportUpdateHandler(IReportService ReportService, IMapper mapper)
        {
            _ReportService = ReportService;
            _mapper = mapper;

        }

        public async Task<ApiResponse<ReportResponse>> Handle(ReportUpdate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ReportResponse>(request);

            if (mapped == null)
                return new ErrorApiResponse<ReportResponse>(ResultMessage.NotUpdatedReport);

            var model = await _ReportService.UpdateReport(mapped);

            var response = _mapper.Map<ReportResponse>(mapped);

            return new SuccessApiResponse<ReportResponse>(response);
        }
    }
}

