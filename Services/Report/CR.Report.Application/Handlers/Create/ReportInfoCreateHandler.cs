using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Helpers;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CR.ReportInfo.Application.Handlers.Create
{
    class ReportInfoInfoCreateHandler : IRequestHandler<ReportInfoCreate, ApiResponse<ReportInfoCreate>>
    {

        private readonly IMapper _mapper;
        private readonly IReportService _ReportService;

        public ReportInfoInfoCreateHandler(IMapper mapper, IReportService ReportService)
        {
            _ReportService = ReportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReportInfoCreate>> Handle(ReportInfoCreate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ReportInfoCreate>(request);

            if (mapped == null)
                return new ErrorApiResponse<ReportInfoCreate>(ResultMessage.notCreatedReportInfo);

            await _ReportService.CreateReportInfo(mapped);

            var response = _mapper.Map<ReportInfoCreate>(mapped);

            return new SuccessApiResponse<ReportInfoCreate>(response);
        }
    }
}