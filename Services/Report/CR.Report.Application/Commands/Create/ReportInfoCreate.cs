using CR.Core.Responses;
using CR.Report.Application.Responses;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CR.Report.Application.Commands.Create
{
    public class ReportInfoCreate : IRequest<ApiResponse<ReportResponse>>
    {

        [BsonElement("ReportName")]
        public string ReportName { get; set; }

        [BsonElement("SavePath")]
        public string SavePath { get; set; }
    }
}
