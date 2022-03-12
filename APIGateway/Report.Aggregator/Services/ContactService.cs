using CR.Core.Responses;
using Newtonsoft.Json;
using Report.Aggregator.Extensions;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Collections.Generic;
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
            string json = JsonConvert.SerializeObject(contactCreate);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/Contact/CreateContact/", httpContent);

            var report = await response.ReadContentAs<ApiResponse<ContactCreate>>();

            return report.Data;
        }

        public async Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate contactInfosCreate)
        {
            string json = JsonConvert.SerializeObject(contactInfosCreate);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/v1/Contact/CreateContactInfo/", httpContent);

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
            var response = await _client.DeleteAsync($"/api/v1/Contact/DeleteContact?id={ Id }");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }

        public async Task<bool> DeleteContactInfo(Guid ContactId, string Key)
        {
            var response = await _client.DeleteAsync($"/api/v1/Contact/DeleteContactInfo?id={ ContactId }&key={Key}");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }

        public async Task<ContactWithInfoCreate> CreateContactWithInfo(ContactWithInfoCreate contactWithInfoCreate)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/CreateContactWithInfo/{ contactWithInfoCreate }");

            var report = await response.ReadContentAs<ApiResponse<ContactWithInfoCreate>>();

            return report.Data;
        }

        public async Task<IEnumerable<ContactCreate>> GetAllContacts()
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetAllContacts");

            var report = await response.ReadContentAs<ApiResponse<IEnumerable<ContactCreate>>>();

            return report.Data;
        }

        public async Task<ContactWithInfoCreate> GetContactWithInfo(Guid Id)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetContactWithInfo?id={Id}");

            var report = await response.ReadContentAs<ApiResponse<ContactWithInfoCreate>>();

            return report.Data;
        }

    }
}
