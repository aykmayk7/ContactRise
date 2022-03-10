using DotNetCore.CAP;
using MassTransit;
using MediatR;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System.Threading.Tasks;

namespace Report.Aggregator.ConsumerServices
{
    public class ConsumerService : ICapSubscribe
    {
        //Masstransit Kullan
        private readonly IMediator _mediatr;
        private readonly IContactService _contactService;
        private readonly IReportService _reportService;  
        
        public ConsumerService(IMediator mediatr)
        {
            _mediatr = mediatr;    
        }

        public async Task Consume(ConsumeContext<ContactCreate> context)
        {
            var contact = _contactService.GetContact(context.Message);
         

            await _mediatr.Send(context);
        }
    }
}
