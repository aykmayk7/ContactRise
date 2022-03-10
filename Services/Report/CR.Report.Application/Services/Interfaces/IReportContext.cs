using CR.Report.Application.Commands.Create;
using MongoDB.Driver;

namespace CR.Report.Application.Services.Interfaces
{
    public interface IReportContext 
    {
        IMongoCollection<ReportCreate> Reports { get; }
        IMongoCollection<ReportInfoCreate> ReportInfo { get; }

    }
}
