using Report.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactCreate> CreateContact(ContactCreate Contact);

        Task<bool> DeleteContact(Guid id);

        Task<bool> DeleteContactInfo(ContactInfoEnum key);

        Task<IEnumerable<ContactCreate>> GetAllContacts();

        Task<ContactCreate> GetContact(Guid Id);

        Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate Contact);

        Task<List<ContactByLocationCreate>> GetContactByLocation(string LocationName);
    }
}