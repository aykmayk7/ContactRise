using CR.Contact.Application.Commands.Create;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Contact.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContact(ContactCreate Contact);
        Task CreateContactInfo(ContactInfosCreate ContactInfos);
        Task<bool> DeleteContact(Guid id);
        Task<bool> DeleteContactInfo(string contactId, string key);
        Task<IEnumerable<ContactCreate>> GetAllContacts();
        Task<ContactWithInfoCreate> GetContactWithInfo(Guid contactId);
        Task<ContactCreate> GetContact(Guid Id);
        Task<IEnumerable<ContactInfosCreate>> GetContactInfo(Guid contactId);
    }
}
