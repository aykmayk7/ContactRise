using CR.Contact.Application.Commands.Create;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Contact.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactCreate> CreateContact(ContactCreate Contact);
        Task<bool> DeleteContact(string id);
        Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate ContactInfos);
        Task<bool> DeleteContactInfo(string id, string key);
        Task<IEnumerable<ContactCreate>> GetAllContacts();
        Task<ContactInfosCreate> GetContactWithInfo(string id);
    }
}
