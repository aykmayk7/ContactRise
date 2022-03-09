using AutoMapper;
using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Helpers;
using CR.Contact.Application.Responses;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Contact.Application.Handlers.Create
{
    public class ContactInfosCreateHandler : IRequestHandler<ContactInfosCreate, ApiResponse<ContactInfosResponse>>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactInfosCreateHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactInfosResponse>> Handle(ContactInfosCreate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ContactInfosCreate>(request);

            if (mapped == null)
                return new ErrorApiResponse<ContactInfosResponse>(ResultMessage.NotCreatedContact);

            var model = await _contactService.CreateContactInfo(mapped);

            var response = _mapper.Map<ContactInfosResponse>(model);

            return new SuccessApiResponse<ContactInfosResponse>(response);
        }
    }
}