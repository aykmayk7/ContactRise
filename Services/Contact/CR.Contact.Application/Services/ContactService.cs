using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
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

        public async Task<ContactByLocationResponse> GetContactByLocation(string locationName)
        {
            ContactByLocationResponse a = new ContactByLocationResponse()
            {
                LocationName = locationName,
                PersonCount = (from c in (from c in _context.ContactInfos.AsQueryable()
                                          where c.Info == ContactInfoEnum.Location
                                          select c)
                               where c.Value == locationName
                               select c).Count().ToString(),

                TelephoneCount = (from c in (from c in _context.ContactInfos.AsQueryable()
                                             where c.Info == ContactInfoEnum.Location
                                             select c)
                                  join d in (from d in _context.ContactInfos.AsQueryable()
                                             where d.Info == ContactInfoEnum.Mobil
                                             select d)
                                             on c.ContactId equals d.ContactId
                                  where c.Value == locationName
                                  select d).Count().ToString()
            };

            return a;

        }
    }
}