using MongoDB.Bson;
using System;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Models
{
    public class ReportCreate
    {
        public string Id { get; set; }
        public BsonDateTime ReportDate { get; set; }
        public BsonDateTime CompletedDate { get; set; }
        public string ReportName { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public string ReportTarget { get; set; }




    }
}
