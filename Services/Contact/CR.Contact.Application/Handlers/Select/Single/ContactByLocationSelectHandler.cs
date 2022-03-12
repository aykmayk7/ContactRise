using AutoMapper;
using CR.Contact.Application.Queries.SingleQuery;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Contact.Application.Handlers.Select.Single
{
    public class ContactByLocationSelectHandler : IRequestHandler<ContactByLocationQuery, ApiResponse<ContactByLocationResponse>>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactByLocationSelectHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactByLocationResponse>> Handle(ContactByLocationQuery request, CancellationToken cancellationToken)
        {
            var data = await _contactService.GetContactByLocation(request.LocationName);

            var response = _mapper.Map<ContactByLocationResponse>(data);

            return new SuccessApiResponse<ContactByLocationResponse>(response);
        }
    }
}