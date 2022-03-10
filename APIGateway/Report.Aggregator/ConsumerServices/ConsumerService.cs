using CR.Core;
using DotNetCore.CAP;
using EventBus.Interfaces;
using MediatR;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Aggregator.ConsumerServices
{
    public class ConsumerService : ICapSubscribe
    {
        //Masstransit Kullan
        private readonly IMediator _mediatr;
        private readonly ICapPublisher _capPublisher;
        private readonly IRabbitMQConsume _rabbitMQConsume;
        private readonly IReportService _reportService;
        private readonly IContactService _contactService;


        public ConsumerService(IMediator mediatr, ICapPublisher capPublisher, IRabbitMQConsume rabbitMQConsume, IReportService reportService, IContactService contactService)
        {
            _mediatr = mediatr;
            _capPublisher = capPublisher;
            _rabbitMQConsume = rabbitMQConsume;
            _reportService = reportService;
            _contactService = contactService;
        }

        [CapSubscribe("")]
        public async Task ReportUpdate()
        {
            string data = await _rabbitMQConsume.ConsumeMessage();

            if (data == null && data == "") return;

            var reportCreate = data.DeserializeObject<ReportCreate>();

            var updateStatus = await _reportService.UpdateReport(reportCreate);

            var contacts = await _contactService.GetAllContacts();


           

        }
    }
}
