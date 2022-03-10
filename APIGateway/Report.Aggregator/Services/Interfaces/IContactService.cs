using Report.Aggregator.Models;
using System;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactCreate> CreateContact(ContactCreate reportCreate);
        Task<bool> DeleteContact(Guid Id);
        Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate reportCreate);
        Task<bool> DeleteContactInfo(Guid ContactId, string Key);
        Task<ContactWithInfoCreate> GetContactWithInfo(ContactWithInfoCreate reportCreate);
    }
}
