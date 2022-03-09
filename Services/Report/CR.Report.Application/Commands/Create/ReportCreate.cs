using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Commands.Create
{
    public class ReportCreate : IRequest<ApiResponse<ReportResponse>>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
     
        public string ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
       
        public string Id { get; set; }
        public ReportCreate()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

    }
}
