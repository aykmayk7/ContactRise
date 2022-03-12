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
    public class ContactSelectHandler : IRequestHandler<ContactQuery, ApiResponse<ContactResponse>>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactSelectHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactResponse>> Handle(ContactQuery request, CancellationToken cancellationToken)
        {
            var data = await _contactService.GetContact(request.Id);

            var response = _mapper.Map<ContactResponse>(data);

            return new SuccessApiResponse<ContactResponse>(response);
        }
    }
}