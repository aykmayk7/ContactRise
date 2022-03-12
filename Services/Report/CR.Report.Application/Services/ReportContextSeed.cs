using CR.Report.Application.Responses;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CR.Report.Application.Services
{
    public static class ReportContextSeed
    {
        public static async void SeedData(IMongoCollection<ReportInfoResponse> reportTypeCollection)
        {
            bool existReportTypePrm = reportTypeCollection.Find(d => true).Any();
            if (existReportTypePrm)
            {
                await reportTypeCollection.InsertManyAsync(GetPreconfiguredReportTypePrms());
            }
        }

        public static IEnumerable<ReportInfoResponse> GetPreconfiguredReportTypePrms()
        {
            return new List<ReportInfoResponse>()
            {
                new ReportInfoResponse()
                {                    
                    ReportName = "Contact List Group By Location",
                    SavePath = "Assets\\Files"                    
                }
            };
        }
    }
}
