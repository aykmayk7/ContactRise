using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CR.Contact.Application.Responses
{
    public class BaseResponse
    {
        public string Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}