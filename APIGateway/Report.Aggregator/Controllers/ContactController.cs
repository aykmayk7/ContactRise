using Microsoft.AspNetCore.Mvc;
using Report.Aggregator.Controllers;
using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace Contact.Aggregator.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService ContactService)
        {
            _contactService = ContactService ?? throw new ArgumentNullException(nameof(ContactService));
        }


        [HttpPost("CreateContact", Name = "CreateContact")]
        public async Task<IActionResult> CreateContact(ContactCreate contactCreate)
        {
            var report = await _contactService.CreateContact(contactCreate);

            return Ok(report);
        }

        [HttpDelete("DeleteContact", Name = "DeleteContact")]
        public async Task<IActionResult> DeleteContact(Guid Id)
        {
            var report = await _contactService.DeleteContact(Id);

            return Ok(report);
        }

        [HttpPost("CreateContactInfo", Name = "CreateContactInfo")]
        public async Task<IActionResult> CreateContactInfo(ContactInfosCreate contactInfosCreate)
        {
            var report = await _contactService.CreateContactInfo(contactInfosCreate);

            return Ok(report);
        }

        [HttpDelete("DeleteContactInfo", Name = "DeleteContactInfo")]
        public async Task<IActionResult> DeleteContactInfo(ContactInfoEnum key)
        {
            var report = await _contactService.DeleteContactInfo(key);

            return Ok(report);
        }

        [HttpGet("GetAllContacts", Name = "GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var report = await _contactService.GetAllContacts();

            return Ok(report);
        }

        [HttpGet("GetContact", Name = "GetContact")]
        public async Task<IActionResult> GetContact(Guid Id)
        {
            var report = await _contactService.GetContact(Id);

            return Ok(report);
        }

        [HttpGet("GetContactByLocation", Name = "GetContactByLocation")]
        public async Task<IActionResult> GetContactByLocation(string LocationName)
        {
            var report = await _contactService.GetContactByLocation(LocationName);

            return Ok(report);
        }

    }
}