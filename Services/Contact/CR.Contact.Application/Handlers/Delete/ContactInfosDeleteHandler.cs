using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Helpers;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.ContactInfosInfos.Application.Handlers.Delete
{
    public class ContactInfosDeleteHandler : IRequestHandler<ContactInfosDelete, ApiResponse>
    {
        private readonly IContactService _contactService;
        public ContactInfosDeleteHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ApiResponse> Handle(ContactInfosDelete request, CancellationToken cancellationToken)
        {
            var mapped = await _contactService.DeleteContactInfo(request.id, request.key);

            if (mapped == false)
                return new ErrorApiResponse(ResultMessage.NotDeletedContact);

            await _contactService.DeleteContactInfo(request.id, request.key);

            return new SuccessApiResponse();

        }
    }
}