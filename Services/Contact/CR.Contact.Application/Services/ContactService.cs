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

        public async Task CreateContact(ContactCreate Contact)
        {
            await _context.Contacts.InsertOneAsync(Contact);
        }

        public async Task CreateContactInfo(ContactInfosCreate ContactInfos)
        {
            await _context.ContactInfos.InsertOneAsync(ContactInfos);
        }

        public async Task<bool> DeleteContact(Guid id)
        {
            FilterDefinition<ContactCreate> filter = Builders<ContactCreate>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Contacts.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public async Task<bool> DeleteContactInfo(string contactId, string key)
        {
            FilterDefinition<ContactInfosCreate> filter = Builders<ContactInfosCreate>.Filter.And(
                Builders<ContactInfosCreate>.Filter.Eq(p => p.ContactId, contactId),
                Builders<ContactInfosCreate>.Filter.Eq(p => p.Key.ToString(), key));

            DeleteResult deleteResult = await _context.ContactInfos.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public async Task<IEnumerable<ContactCreate>> GetAllContacts()
        {
            return await _context.Contacts.Find(p => true).ToListAsync();
        }

        public async Task<ContactWithInfoCreate> GetContactWithInfo(Guid id)
        {
            return await _context.ContactWithInfo.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ContactCreate> GetContact(Guid id)
        {
            return await _context.Contacts.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ContactInfosCreate>> GetContactInfo(Guid contactId)
        {
            return await _context.ContactInfos.Find(p => p.ContactId == contactId.ToString()).ToListAsync();
        }
    }
}

