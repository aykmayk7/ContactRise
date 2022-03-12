using AutoMapper;
using CR.Core;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Helpers;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Create
{
    public class ReportCreateHandler : IRequestHandler<ReportCreate, ApiResponse<ReportResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IReportService _reportService;


        public ReportCreateHandler(IMapper mapper, IReportService reportService)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReportResponse>> Handle(ReportCreate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ReportResponse>(request);
            
            mapped.ReportDate = DateTime.Now;
            mapped.ReportName = request.ReportName;
            mapped.ReportStatus = Enumerations.ReportStatusEnum.NotReady;

            if (mapped == null)
                return new ErrorApiResponse<ReportResponse>(ResultMessage.NotCreatedReport);

            await _reportService.CreateReport(mapped);

            var response = _mapper.Map<ReportResponse>(mapped);

            return new SuccessApiResponse<ReportResponse>(response);
        }
    }
}