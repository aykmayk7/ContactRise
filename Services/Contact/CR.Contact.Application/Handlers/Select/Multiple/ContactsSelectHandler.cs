using AutoMapper;
using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Queries.MultipleQuery;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Contact.Application.Handlers.Select.Multiple
{
    public class ContactsSelectHandler : IRequestHandler<ContactsQuery, ApiResponse<IEnumerable<ContactResponse>>>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactsSelectHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ContactResponse>>> Handle(ContactsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ContactResponse> data = await _contactService.GetAllContacts();

            var response = _mapper.Map<IEnumerable<ContactResponse>>(data);

            return new SuccessApiResponse<IEnumerable<ContactResponse>>(response);
        }
    }
}