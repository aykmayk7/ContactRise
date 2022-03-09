﻿using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Helpers;
using CR.Contact.Application.Services.Interfaces;
using CR.Core.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Contact.Application.Handlers.Delete
{
    public class ContactDeleteHandler : IRequestHandler<ContactDelete, ApiResponse>
    {
        private readonly IContactService _contactService;
        public ContactDeleteHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ApiResponse> Handle(ContactDelete request, CancellationToken cancellationToken)
        {
            var mapped = await _contactService.DeleteContact(request.id);

            if (mapped == false)
                return new ErrorApiResponse(ResultMessage.NotDeletedContact);

            await _contactService.DeleteContact(request.id);

            return new SuccessApiResponse();

        }
    }
}