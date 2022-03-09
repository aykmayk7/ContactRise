﻿using AutoMapper;
using CR.Core.Responses;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Helpers;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Report.Application.Handlers.Create
{
    public class ReportCreateHandler : IRequestHandler<ReportCreate, ApiResponse<ReportResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IReportService _ReportService;

        public ReportCreateHandler(IMapper mapper, IReportService ReportService)
        {
            _ReportService = ReportService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReportResponse>> Handle(ReportCreate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ReportCreate>(request);

            if (mapped == null)
                return new ErrorApiResponse<ReportResponse>(ResultMessage.NotCreatedReport);

            var model = await _ReportService.CreateReport(mapped);

            var response = _mapper.Map<ReportResponse>(model);

            return new SuccessApiResponse<ReportResponse>(response);
        }
    }
}