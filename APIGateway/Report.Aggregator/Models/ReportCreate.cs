using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Models
{
    public class ReportCreate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public BsonDateTime ReportDate { get; set; }
        public BsonDateTime CompletedDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public string ReportName { get; set; }


    }
}
