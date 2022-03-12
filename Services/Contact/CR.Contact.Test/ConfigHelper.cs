using AutoMapper;
using CR.Contact.Application.Mappers;
using CR.Contact.Application.Services;
using CR.Contact.Application.Services.Interfaces;
using CR.Contact.Controllers;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CR.Contact.Test
{
    public class ConfigHelper
    {
        private readonly IConfiguration _configuration;

        private readonly IContactContext _ContactContext;
        private readonly IMediator _mediatr;

        public IMapper GetAutoMapperConfig()
        {
            var mapperConfig = new MapperConfiguration(d =>
            {
                d.AddProfile<MappingProfile>();
            });
            return mapperConfig.CreateMapper();
        }

        public ConfigHelper(IConfiguration configuration, IMediator mediator, IContactContext ContactContext)
        {

            _configuration = configuration;
            _mediatr = mediator;
            _ContactContext = ContactContext;

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
            return new ContactController(_mediatr);
        }

        public static void Dispose()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("ContactDb");
        }
    }
}
