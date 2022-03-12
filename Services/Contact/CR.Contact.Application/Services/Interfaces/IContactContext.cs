using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using MongoDB.Driver;

namespace CR.Contact.Application.Services.Interfaces
{
    public interface IContactContext
    {
        IMongoCollection<ContactResponse> Contacts { get; }
        IMongoCollection<ContactInfosResponse> ContactInfos { get; }
        IMongoCollection<ContactByLocationResponse> ContactByLocationResponse { get; }
     
    }
}
