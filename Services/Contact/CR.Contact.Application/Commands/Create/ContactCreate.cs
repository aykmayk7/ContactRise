using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactCreate : IRequest<ApiResponse<ContactResponse>>
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public string Id { get; set; }
        public ContactCreate()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
