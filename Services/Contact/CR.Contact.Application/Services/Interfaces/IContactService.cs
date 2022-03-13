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

        Task CreateContact(ContactResponse Contact);

        Task<bool> DeleteContact(string id);

        Task<bool> DeleteContactInfo(ContactInfoEnum key);

        Task<IEnumerable<ContactResponse>> GetAllContacts();

        Task<ContactResponse> GetContact(Guid Id);

        Task CreateContactInfo(ContactInfosResponse Contact);

        Task<ContactByLocationResponse> GetContactByLocation(string LocationName);


    }
}
