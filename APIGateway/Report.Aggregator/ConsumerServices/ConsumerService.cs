using CR.Core;
using DotNetCore.CAP;
using MediatR;
using Report.Aggregator.Models;
using System.Threading.Tasks;

namespace Report.Aggregator.ConsumerServices
{
    public class ConsumerService : ICapSubscribe
    {
        private readonly IMediator _mediatr;
        private readonly ICapPublisher _capPublisher;
        
        public ConsumerService(IMediator mediatr, ICapPublisher capPublisher)
        {
            _mediatr = mediatr;
            _capPublisher = capPublisher;
        }

        [CapSubscribe("report-queue")]
        public async Task ReportConsume(string value)
        {
            var command = value.DeserializeObject<QueueService<ContactResponse>>().Data;

            var response = await _mediatr.Send(command);

            // Kuyruklara Sipariş bilgisini gönderiyoruz.
            if (response.Success && response.Data != null)
            {
                await _capPublisher.PublishAsync("report-queue", value);
            }
            else
            {
                await _capPublisher.PublishAsync("payment.fail.event", value);
            }
        }

    }

}
