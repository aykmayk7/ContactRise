using CR.Core;
using DotNetCore.CAP;
using EventBus;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System.Threading.Tasks;

namespace Report.Aggregator.ConsumerServices
{
    public class ConsumerService : ICapSubscribe
    {

        private readonly ICapPublisher _capPublisher;
        private readonly IReportService _reportService;
        private readonly IContactService _contactService;
        public ConsumerService(ICapPublisher capPublisher, IReportService reportService, IContactService contactService)
        {

            _capPublisher = capPublisher;
            _reportService = reportService;
            _contactService = contactService;
        }

        [CapSubscribe(EventBusConstants.ReportQueue)]
        public async Task ReportUpdate(string value)
        {
            if (value == null) return;

            var command = QueueExtensions.DeserializeObject<ReportCreate>(value);

            command.ReportStatus = Enumerations.ReportStatusEnum.Ready;

            var updateStatus = await _reportService.UpdateReport(command);

            var contacts = await _contactService.GetAllContacts();







            await _capPublisher.PublishAsync(EventBusConstants.ReportQueue, value);
        }
    }
}
