using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
using MassTransit;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Report.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        public ReportService(IReportContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }
        public async Task CreateReport(ReportCreate Report)
        {
            await _context.Reports.InsertOneAsync(Report);
            var durum = _publishEndpoint.Publish<ReportCreate>(Report);
        }

        public async Task<IEnumerable<ReportResponse>> GetAllReport()
        {
            await _context.Reports.Find(p => true).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<ReportCreate> GetReport(DateTime date)
        {
            return await _context.Reports.Find(p => p.ReportDate == date).FirstOrDefaultAsync();

        }


    }
}
