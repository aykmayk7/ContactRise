using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CR.Report.Application.Responses
{
    public class ReportInfoResponse : BaseResponse
    {
        [BsonElement("ReportId")]
        public Guid ReportId{ get; set; }

        [BsonElement("ReportName")]
        public string ReportName { get; set; }

        [BsonElement("SavePath")]
        public string SavePath { get; set; }
    }
}
