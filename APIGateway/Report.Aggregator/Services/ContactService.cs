using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Report.Aggregator.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;
        public ContactService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public Task<ContactResponse> GetContact(ReportCreate reportCreate)
        {
           
        }
    }
}
