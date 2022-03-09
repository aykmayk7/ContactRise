using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Commands.Create
{
    public class ReportCreate : IRequest<ApiResponse<ReportResponse>>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get
            {
                return (Id == null || Id == "" ? ObjectId.GenerateNewId().ToString() : Id);
            }

            set => Id = ObjectId.GenerateNewId().ToString();
        }
        public DateTime ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }

    }
}
