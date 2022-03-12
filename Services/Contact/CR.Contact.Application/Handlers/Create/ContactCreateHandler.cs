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
    public class ContactCreateHandler : IRequestHandler<ContactCreate, ApiResponse<ContactResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactCreateHandler(IMapper mapper, IContactService contactService)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactResponse>> Handle(ContactCreate request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<ContactResponse>(request);

            if (mapped == null)
                return new ErrorApiResponse<ContactResponse>(ResultMessage.NotCreatedContact);

            await _contactService.CreateContact(mapped);

            //var response = _mapper.Map<ContactResponse>(mapped);

            return new SuccessApiResponse<ContactResponse>(mapped);
        }
    }
}