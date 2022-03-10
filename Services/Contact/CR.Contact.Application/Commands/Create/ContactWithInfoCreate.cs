using CR.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactWithInfoCreate : IRequest<ApiResponse<ContactWithInfoCreate>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public ICollection<ContactInfosCreate> ContactInfo { get; set; }

    }
}
