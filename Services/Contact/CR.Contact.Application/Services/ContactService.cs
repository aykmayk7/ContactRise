using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Contact.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactContext _context;
        public ContactService(IContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ContactCreate> CreateContact(ContactCreate Contact)
        {
            await _context.Contacts.InsertOneAsync(Contact);
            throw new NotImplementedException();
        }

        public async Task<ContactInfosCreate> CreateContactInfo(ContactInfosCreate ContactInfos)
        {
            await _context.ContactInfos.InsertOneAsync(ContactInfos);
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteContact(string id)
        {
            FilterDefinition<ContactCreate> filter = Builders<ContactCreate>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Contacts.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteContactInfo(string id, string key)
        {
            FilterDefinition<ContactInfosCreate> filter = Builders<ContactInfosCreate>.Filter.And(
                Builders<ContactInfosCreate>.Filter.Eq(p => p.ContactId.ToString(), id),
                Builders<ContactInfosCreate>.Filter.Eq(p => p.Key.ToString(), key));

            DeleteResult deleteResult = await _context.ContactInfos.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactCreate>> GetAllContacts()
        {
            return await _context.Contacts.Find(p => true).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<ContactInfosCreate> GetContactWithInfo(string id)
        {
            return await _context.ContactInfos.Find(p => p.ContactId.ToString() == id).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }
    }
}
