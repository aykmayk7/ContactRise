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
 
        
        public ConsumerService(IMediator mediatr)
        {
            _mediatr = mediatr;    
        }

        public async Task Consume(ConsumeContext<ContactCreate> context)
        {
       
        }
    }
}
