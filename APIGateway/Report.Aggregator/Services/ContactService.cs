using CR.Core.Responses;
using Newtonsoft.Json;
using Report.Aggregator.Extensions;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

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

        public async Task<bool> DeleteContact(Guid Id)
        {
            var response = await _client.DeleteAsync($"/api/v1/Contact/DeleteContact?id={ Id }");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }

        public async Task<bool> DeleteContactInfo(ContactInfoEnum Key)
        {
            var response = await _client.DeleteAsync($"/api/v1/Contact/DeleteContactInfo?key={Key}");

            var report = await response.ReadContentAs<ApiResponse<bool>>();

            return report.Success;
        }

        public async Task<IEnumerable<ContactCreate>> GetAllContacts()
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetAllContacts");

            var report = await response.ReadContentAs<ApiResponse<IEnumerable<ContactCreate>>>();

            return report.Data;
        }

        public async Task<ContactCreate> GetContact(Guid Id)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetContact?id={ Id }");
            
            var report = await response.ReadContentAs<ApiResponse<ContactCreate>>();

            return report.Data;
        }

        public async Task<List<ContactByLocationCreate>> GetContactByLocation(string LocationName)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/GetContactByLocation?locationname={ LocationName}");

            var report = await response.ReadContentAs<ApiResponse<List<ContactByLocationCreate>>>();

            return report.Data;
        }

    }
}
