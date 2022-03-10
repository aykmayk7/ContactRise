using CR.Core.Responses;
using Report.Aggregator.Extensions;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ContactCreate> GetContact(ContactCreate contactCreate)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetContactInfos?id={ contactCreate.Id }");

            var report = await response.ReadContentAs<ApiResponse<ContactCreate>>();

            return report.Data;
        }
    }
}
