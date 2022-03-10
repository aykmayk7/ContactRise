using CR.Report.Application.Commands.Create;
using CR.Report.Application.Services.Interfaces;
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
        public async Task CreateReport(ReportCreate Report)
        {
            await _context.Reports.InsertOneAsync(Report);
        }

        public async Task CreateReportInfo(ReportInfoCreate reportInfo)
        {
            await _context.ReportInfo.InsertOneAsync(reportInfo);
        }

        public async Task<IEnumerable<ReportCreate>> GetAllReport()
        {
            var durum = await _context.Reports.Find(p => true).ToListAsync();
            return (IEnumerable<ReportCreate>)durum;
        }

        public async Task<ReportCreate> GetReport(string date)
        {
            return await _context.Reports.Find(p => p.ReportDate == date).FirstOrDefaultAsync();
        }

        public async Task<ReportInfoCreate> GetReportInfo(string Date)
        {
            return await _context.ReportInfo.Find(p => p.CreatedTime == Date).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateReport(ReportCreate reportCreate)
        {
            var updateResult = await _context
                                      .Reports
                                      .ReplaceOneAsync(filter: g => g.Id == reportCreate.Id, replacement: reportCreate);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
