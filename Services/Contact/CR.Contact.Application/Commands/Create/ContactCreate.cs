using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactCreate : IRequest<ApiResponse<ContactResponse>>
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public IEnumerable<ContactInfosCreate> ContactInfos { get; set; }

    }
}
