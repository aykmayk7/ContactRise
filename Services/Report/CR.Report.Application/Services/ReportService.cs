﻿using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using CR.Report.Application.Services.Interfaces;
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
        public ReportService(IReportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ReportResponse> CreateReport(ReportCreate Report)
        {
            await _context.Reports.InsertOneAsync(Report);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReportResponse>> GetAllReport()
        {
            await _context.Reports.Find(p => true).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<ReportCreate> GetReport(string date)
        {
            return await _context.Reports.Find(p => p.ReportDate == date).FirstOrDefaultAsync();
           
        }


    }
}
