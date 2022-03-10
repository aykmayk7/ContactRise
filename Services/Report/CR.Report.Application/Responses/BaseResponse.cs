using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CR.Report.Application.Responses
{
    public class BaseResponse
    {
        public Guid Id { get; set; }

    }
}
