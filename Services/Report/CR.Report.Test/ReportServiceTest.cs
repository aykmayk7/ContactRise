using AutoMapper;
using CR.Report.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Report.Test
{
    public class ReportServiceTest
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportServiceTest(IReportService reportService, IMapper mapper)
        {
            _mapper = ConfigHelper.GetAutoMapperConfig();
            _reportService = ConfigHelper.GetReportService();
        }
    }
}
