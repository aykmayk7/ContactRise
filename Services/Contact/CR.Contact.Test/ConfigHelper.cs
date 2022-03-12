using AutoMapper;
using CR.Contact.Application.Mappers;
using CR.Contact.Application.Services;
using CR.Contact.Application.Services.Interfaces;
using CR.Contact.Controllers;
using DotNetCore.CAP;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;

namespace CR.Contact.Test
{
    public class ConfigHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _ContactService;
        private readonly IContactContext _ContactContext;
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

        public ConfigHelper(IConfiguration configuration, IContactService ContactService, IMediator mediator, IContactContext ContactContext, IPublishEndpoint publishEndpoint)
        {
            _ContactService = ContactService;
            _configuration = configuration;
            _mediatr = mediator;
            _ContactContext = ContactContext;
            _publishEndpoint = publishEndpoint;
        }

        public ContactContext GetContactDbContext()
        {
            return new ContactContext(_configuration);
        }

        public ContactService GetContactService()
        {
            return new ContactService(_ContactContext);
        }

        public ContactController GetContactController()
        {
            var _mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var _mockPublisher = new Mock<ICapPublisher>();

            return new ContactController(_mediatr, _mockPublishEndpoint, _mockPublisher);
        }

        public static void Dispose()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("ContactDb");
        }
    }
}
