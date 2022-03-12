using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using MongoDB.Driver;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportContext 
    {
        IMongoCollection<ReportResponse> Reports { get; }
        

    }
}
