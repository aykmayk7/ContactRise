using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;

namespace CR.Report.Application.Commands.Create
{
    public class ReportCreate : IRequest<ApiResponse<ReportResponse>>
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }
        //public BsonDateTime ReportDate { get; set; }
        //public BsonDateTime CompletedDate { get; set; }
        //public string ReportTarget { get; set; }
        //public ReportStatusEnum ReportStatus { get; set; }
        public string ReportName { get; set; }

    }
}
