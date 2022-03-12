using CR.Report.Application.Commands.Create;
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

        }
        public IMongoCollection<ReportResponse> Reports { get; }
        
               
    }
}
