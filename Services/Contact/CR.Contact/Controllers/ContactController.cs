using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Queries.MultipleQuery;
using CR.Contact.Application.Queries.SingleQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace CR.Contact.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : BaseController
    {
        private readonly IMediator _mediatr;
        public ContactController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var query = new ContactDelete(id);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpDelete("DeleteContactInfo")]
        public async Task<IActionResult> DeleteContactInfo( ContactInfoEnum key)
        {
            var query = new ContactInfosDelete(key);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var query = new ContactsQuery();

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact(Guid Id)
        {
            var query = new ContactQuery(Id);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpPost("CreateContactInfo")]
        public async Task<IActionResult> CreateContactInfo([FromBody] ContactInfosCreate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) return NotFound(result);

            return result.Success ? Success(result) : BadRequest(result);
        }

        [HttpGet("GetContactByLocation")]
        public async Task<IActionResult> GetContactByLocation(string LocationName)
        {
            var query = new ContactByLocationQuery(LocationName);

            var result = await _mediatr.Send(query);

            if (result == null) return NotFound();

            return result.Success ? Success(result) : BadRequest(result);
        }
    }
}
