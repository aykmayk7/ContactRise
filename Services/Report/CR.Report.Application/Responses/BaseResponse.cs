using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CR.Report.Application.Responses
{
    public class BaseResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
