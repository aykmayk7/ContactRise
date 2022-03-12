using AutoMapper;
using MassTransit;
using Report.Aggregator.ConsumerServices.Interfaces;
using Report.Aggregator.Models;
using Report.Aggregator.Models.Excel;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace Report.Aggregator.ConsumerServices
{
    public class ConsumerService : IConsumer<ReportCreate>
    {
        private readonly IMapper _mapper;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IContactService _contactService;
        private readonly IReportService _reportService;

        public ConsumerService(IMapper mapper, IBackgroundTaskQueue taskQueue, IContactService contactService, IReportService reportService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _taskQueue = taskQueue ?? throw new ArgumentNullException(nameof(taskQueue));
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
        }

        public async Task Consume(ConsumeContext<ReportCreate> context)
        {
            await _taskQueue.QueueBackgroundWorkItemAsync(async token =>
            {
                await GenerateReport(context, token);
            });
        }

        private async Task GenerateReport(ConsumeContext<ReportCreate> context, CancellationToken cancellationToken)
        {
            var reportEntity = _mapper.Map<ReportCreate>(context.Message);

            var report = await _reportService.GetReport(reportEntity.Id);
            var reportInfo = await _reportService.GetReportInfo();

            reportEntity.ReportStatus = ReportStatusEnum.Processing;
            await _reportService.UpdateReport(reportEntity);

            var result = _contactService.GetContactByLocation(String.Empty);

            var excelModel = _mapper.Map<List<ExcelModel>>(result.Result);

            string fileName = $"{reportInfo.ReportName}_{DateTime.Now.ToString("dd_MM_yyyy_HHmmss")}";
            string path = reportInfo.SavePath;
            byte[] filecontent = ExcelExportHelper.ExportExcel(excelModel, fileName, true);
            filecontent.SaveToExcel(path, fileName, out fileName);

            reportEntity.CompletedDate = DateTime.Now;
            reportEntity.ReportTarget = fileName;
            reportEntity.ReportStatus = ReportStatusEnum.Ready;
            await _reportService.UpdateReport(reportEntity);

            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}
