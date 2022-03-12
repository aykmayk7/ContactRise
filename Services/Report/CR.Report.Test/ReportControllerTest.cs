using CR.Report.Application.Commands.Create;
using CR.Report.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace CR.Report.Test
{
    public class ReportControllerTest
    {
        private readonly ReportController _reportController;


        [Fact]
        public async Task ReportController_ActionExecutes_ReturnsViewForList()
        {
            var result = await _reportController.GetAllReports();

        }

        public async Task ReportController_ActionExecutes_ReturnsViewForCreateReport(ReportCreate reportCreate)
        {

            var result = await _reportController.CreateReport(reportCreate);

        }
    }
}
