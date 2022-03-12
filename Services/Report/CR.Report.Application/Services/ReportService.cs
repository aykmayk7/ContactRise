using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CR.Report.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportContext _context;

        public ReportService(IReportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateReport(ReportResponse Report)
        {
            await _context.Reports.InsertOneAsync(Report);
        }       

        public async Task<IEnumerable<ReportResponse>> GetAllReport()
        {
            var durum = await _context.Reports.Find(p => true).ToListAsync();
            return (IEnumerable<ReportResponse>)durum;
        }

        public async Task<ReportResponse> GetReport(string Id)
        {
            return await _context.Reports.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }
   
        public async Task<bool> UpdateReport(ReportResponse reportCreate)
        {
            var updateResult = await _context
                                      .Reports
                                      .ReplaceOneAsync(filter: g => g.Id == reportCreate.Id, replacement: reportCreate);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
