using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using CR.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactContext _context;
        public ContactService(IContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateContact(ContactResponse Contact)
        {
            await _context.Contacts.InsertOneAsync(Contact);
        }

        public async Task<bool> DeleteContact(string id)
        {
            FilterDefinition<ContactResponse> filter = Builders<ContactResponse>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Contacts.DeleteOneAsync(filter, default);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public async Task<bool> DeleteContactInfo(ContactInfoEnum key)
        {
            FilterDefinition<ContactInfosResponse> filter = Builders<ContactInfosResponse>.Filter.And(
                            Builders<ContactInfosResponse>.Filter.Eq(p => p.Info, key));

            DeleteResult deleteResult = await _context.ContactInfos.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public async Task<IEnumerable<ContactResponse>> GetAllContacts()
        {
            //return await _context.Contacts.Find(p => true).ToListAsync();

            var durum = from c in _context.Contacts.AsQueryable()
                        join i in _context.ContactInfos.AsQueryable()
                               on c.ContactId equals i.ContactId
                               into joinedContactInfos
                        select new ContactResponse
                        {
                            Name = c.Name,
                            Surname = c.Surname,
                            Company = c.Company,
                            ContactId = c.ContactId,
                            ContactInfos = joinedContactInfos
                        };
            return durum;

        }

        public async Task<ContactResponse> GetContact(Guid id)
        {
            //return await _context.Contacts.Find(p => p.Id == id).FirstOrDefaultAsync();

            var durum = from c in _context.Contacts.AsQueryable()
                        join i in _context.ContactInfos.AsQueryable()
                               on c.ContactId equals i.ContactId
                               into joinedContactInfos
                        select new ContactResponse
                        {
                            Name = c.Name,
                            Surname = c.Surname,
                            Company = c.Company,
                            ContactId = c.ContactId,
                            ContactInfos = joinedContactInfos
                        };

            return durum.Where(p => p.ContactId == id).FirstOrDefault();
        }

        public async Task CreateContactInfo(ContactInfosResponse Contact)
        {
            await _context.ContactInfos.InsertOneAsync(Contact);
        }

        public async Task<List<ContactByLocationResponse>> GetContactByLocation(string locationName)
        {
            //var report = (from contact in _context.ContactInfos.
            //              where contact.Info == ContactInfoEnum.Location
            //              group contact by new
            //              {
            //                  contact.Value
            //              }
            //              into contactGroup
            //              select new ContactByLocationResponse
            //              {
            //                  LocationName = contactGroup.Key.Value,
            //                  PersonCount = 0,
            //                  TelephoneCount = 0
            //                  //PersonCount = (from c in _context.Contacts.AsQueryable()
            //                  //               where c.ContactId == contactGroup.Key.ContactId
            //                  //               select c).Count()

            //                  //TelephoneCount = (from c in (from c in _context.PersonContactInfos
            //                  //                             where c.InfoType == ContactInfoType.Location
            //                  //                             select c)
            //                  //                  join d in (from d in _context.PersonContactInfos
            //                  //                             where d.InfoType == ContactInfoType.PhoneNumber
            //                  //                             select d) on c.PersonId equals d.PersonId
            //                  //                  where c.InfoDetail == contactGroup.Key.InfoDetail
            //                  //                  select d).Count()
            //              }).Distinct();

            //if (!string.IsNullOrWhiteSpace(locationName))
            //    report = report.Where(d => d.LocationName == locationName);

            return default;


            //return report.ToList();
        }
    }
}

