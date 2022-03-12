using AutoMapper;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Commands.Update;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using Xunit;
using static CR.Report.Test.DataHelper;

namespace CR.Report.Test
{
    public class ReportServiceTest
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        ConfigHelper ConfigHelper;
        public ReportServiceTest(IReportService reportService, IMapper mapper)
        {
            _mapper = ConfigHelper.GetAutoMapperConfig();
            _reportService = ConfigHelper.GetReportService();
        }

        [Theory]
        [ClassData(typeof(CreateReportObj))]
        public async void CreateReport_CreateReportObj(ReportCreate reportCreate)
        {

            var reportEntity = _mapper.Map<ReportResponse>(reportCreate);
            reportEntity.ReportName = "DENEME";

            await _reportService.CreateReport(reportEntity);

        }

        [Theory]
        [ClassData(typeof(UpdateReportObj))]
        public async void UpdateReport_UpdateReportObj(ReportUpdate reportUpdate)
        {

            var reportEntity = _mapper.Map<ReportResponse>(reportUpdate);

            var result = await _reportService.UpdateReport(reportEntity);

        }

        [Fact]
        public async void GetAllReports()
        {

            string id = DataHelper.GetTestReportId();

            var result = await _reportService.GetAllReport();

        }

        [Fact]
        public async void GetReportInfo()
        {            

            var result = await _reportService.GetReportInfo();

        }
    }
}
