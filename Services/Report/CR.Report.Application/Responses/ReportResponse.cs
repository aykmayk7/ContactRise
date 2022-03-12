using MongoDB.Bson;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Responses
{
    public class ReportResponse : BaseResponse
    {
        public BsonDateTime ReportDate { get; set; }
        public BsonDateTime CompletedDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public string ReportName { get; set; }


    }
}
