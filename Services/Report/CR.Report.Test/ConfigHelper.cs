using AutoMapper;
using CR.Report.Application.Mappers;
using CR.Report.Application.Services;
using CR.Report.Application.Services.Interfaces;
using CR.Report.Controllers;
using DotNetCore.CAP;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;

namespace CR.Report.Test
{
    public class ConfigHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IReportService _reportService;
        private readonly IReportContext _reportContext;
        private readonly IMediator _mediatr;
        private readonly IPublishEndpoint _publishEndpoint;
        public IMapper GetAutoMapperConfig()
        {
            var mapperConfig = new MapperConfiguration(d =>
            {
                d.AddProfile<MappingProfile>();
            });
            return mapperConfig.CreateMapper();
        }

        public ConfigHelper(IConfiguration configuration, IReportService reportService, IMediator mediator, IReportContext reportContext,IPublishEndpoint publishEndpoint)
        {
            _reportService = reportService;
            _configuration = configuration;
            _mediatr = mediator;
            _reportContext = reportContext;
            _publishEndpoint = publishEndpoint;
        }

        public ReportContext GetContactDbContext()
        {
            return new ReportContext(_configuration);
        }

        public ReportService GetReportService()
        {
            return new ReportService(_reportContext);
        }

        public ReportController GetReportController()
        {
            var _mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var _mockPublisher = new Mock<ICapPublisher>();

            return new ReportController(_mediatr, _mockPublishEndpoint, _mockPublisher);
        }

        public static void Dispose()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("ReportDb");
        }
    }
}
