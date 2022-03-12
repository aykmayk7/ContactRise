using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CR.Contact.Application.Services
{
    public class ContactContext : IContactContext
    {
        public ContactContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
                       

            Contacts = database.GetCollection<ContactResponse>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ContactInfos = database.GetCollection<ContactInfosCreate>(configuration.GetValue<string>("DatabaseSettings:CollectionName2"));
            ContactWithInfo = database.GetCollection<ContactWithInfoCreate>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            
        }
        public IMongoCollection<ContactResponse> Contacts { get; }

        public IMongoCollection<ContactInfosCreate> ContactInfos { get; }

        public IMongoCollection<ContactWithInfoCreate> ContactWithInfo { get; }
    }
}
