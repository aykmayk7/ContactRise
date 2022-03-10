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
    public class ContactInfoSelectHandler : IRequestHandler<ContactInfoQuery, ApiResponse<ContactInfosResponse>>
    {

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactInfoSelectHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactInfosResponse>> Handle(ContactInfoQuery request, CancellationToken cancellationToken)
        {
            var model = await _contactService.GetContactWithInfo(System.Guid.Empty);

            var response = _mapper.Map<ContactInfosResponse>(model);

            return new SuccessApiResponse<ContactInfosResponse>(response);
        }
    }
}