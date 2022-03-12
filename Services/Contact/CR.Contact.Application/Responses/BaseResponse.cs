using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CR.Contact.Application.Responses
{
    public class BaseResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

    }
}