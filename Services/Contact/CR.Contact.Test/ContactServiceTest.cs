using AutoMapper;
using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using System;
using Xunit;
using static CR.Contact.Test.DataHelper;

namespace CR.Contact.Test
{
    public class ContactServiceTest
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;
        ConfigHelper ConfigHelper;
        public ContactServiceTest(IContactService ContactService, IMapper mapper)
        {
            _mapper = ConfigHelper.GetAutoMapperConfig();
            _ContactService = ConfigHelper.GetContactService();
        }

        [Theory]
        [ClassData(typeof(CreateContactObj))]
        public async void CreateContact_CreateContactObj(ContactCreate ContactCreate)
        {

            var Contact = _mapper.Map<ContactResponse>(ContactCreate);
            Contact.Name = "Aykan";
            Contact.Surname = "CESUR";
            Contact.Company = "RISE";


            await _ContactService.CreateContact(Contact);

        }

        [Theory]
        [ClassData(typeof(DeleteContactObj))]
        public async void DeleteContact_DeleteContactObj(string Id)
        {

            var Contact = _mapper.Map<ContactDelete>(Id);

            var result = await _ContactService.DeleteContact(Contact.Id);

        }

        [Fact]
        public async void GetAllContacts()
        {

            var result = await _ContactService.GetAllContacts();

        }

        [Fact]
        public async void GetContactInfo()
        {
            var result = await _ContactService.GetContact(Guid.NewGuid());
        }
    }
}
