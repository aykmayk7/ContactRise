using CR.Contact.Application.Commands.Create;
using MongoDB.Driver;

namespace CR.Contact.Application.Services.Interfaces
{
    public interface IContactContext
    {
        IMongoCollection<ContactCreate> Contacts { get; }
        IMongoCollection<ContactInfosCreate> ContactInfos { get; }
        IMongoCollection<ContactWithInfoCreate> ContactWithInfo { get; }

    }
}
