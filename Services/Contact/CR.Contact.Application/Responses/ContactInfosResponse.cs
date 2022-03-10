using CR.Contact.Application.Commands.Create;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CR.Contact.Application.Responses
{
    public class ContactInfosResponse : BaseResponse
    {

        public string ContactId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }


    }
}
