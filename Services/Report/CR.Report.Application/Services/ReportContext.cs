using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CR.Report.Application.Services
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Reports = database.GetCollection<ReportResponse>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ReportInfo = database.GetCollection<ReportInfoResponse>(configuration.GetValue<string>("DatabaseSettings:CollectionName2"));            

        }
        public IMongoCollection<ReportResponse> Reports { get; }
        public IMongoCollection<ReportInfoResponse> ReportInfo { get; }
        
               
    }
}
