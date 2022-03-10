using CR.Core.Responses;
using Report.Aggregator.Extensions;
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
        public async Task<ContactCreate> CreateContact(ContactCreate contactCreate)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/CreateContact/{ contactCreate }");

            var report = await response.ReadContentAs<ApiResponse<ContactCreate>>();

            return report.Data;
        }

        public async Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate contactInfosCreate)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/CreateContactInfo/{ contactInfosCreate }");

            var report = await response.ReadContentAs<ApiResponse<ContactInfosCreate>>();

            return report.Data;
        }

        public async Task<ContactWithInfoCreate> GetContactWithInfo(ContactWithInfoCreate contactWithInfoCreate)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/CreateContactInfo?id={ contactWithInfoCreate.Id }");

            var report = await response.ReadContentAs<ApiResponse<ContactWithInfoCreate>>();

            return report.Data;
        }

        public async Task<bool> DeleteContact(Guid Id)
        {
            var response = await _client.GetAsync($"/api/v1/Contact//api/v1/Contact/DeleteContact?id={ Id }");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }

        public async Task<bool> DeleteContactInfo(Guid ContactId, string Key)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/DeleteContactInfo?id={ ContactId }&key={Key}");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }
    }
}
