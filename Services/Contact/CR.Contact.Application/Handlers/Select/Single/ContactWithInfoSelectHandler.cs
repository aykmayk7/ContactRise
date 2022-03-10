using AutoMapper;
using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Queries.SingleQuery;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Contact.Application.Handlers.Select.Single
{
    public class ContactWithInfoSelectHandler : IRequestHandler<ContactWithInfoQuery, ApiResponse<ContactWithInfoCreate>>
    {

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactWithInfoSelectHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactWithInfoCreate>> Handle(ContactWithInfoQuery request, CancellationToken cancellationToken)
        {
            if (request == null) return null;

            var model1 = await _contactService.GetContact(request.Id);
            var model2 = await _contactService.GetContactInfo(request.Id);

            ContactWithInfoCreate a = new ContactWithInfoCreate();
            a.Id = model1.Id;
            a.Name = model1.Name;
            a.Surname = model1.Surname;
            a.Company = model1.Company;
            a.ContactInfo = (System.Collections.Generic.ICollection<ContactInfosCreate>)model2;

            var response = _mapper.Map<ContactWithInfoCreate>(a);

            return new SuccessApiResponse<ContactWithInfoCreate>(response);
        }
    }
}