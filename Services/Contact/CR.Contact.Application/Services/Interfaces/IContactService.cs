using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactResponse> CreateContact(ContactCreate Contact);
        Task<bool> DeleteContact(Guid id);
        Task<bool> DeleteContactInfo(Guid contactId, ContactInfoEnum key);
        Task<IEnumerable<ContactResponse>> GetAllContacts();
        Task<ContactWithInfoCreate> GetContactWithInfo(Guid contactId);
        Task<ContactResponse> GetContact(Guid Id);
        Task<IEnumerable<ContactInfosCreate>> GetContactInfo(Guid contactId);
        Task<IEnumerable<ContactWithInfoCreate>> GetAllContactInfo();
    }
}
