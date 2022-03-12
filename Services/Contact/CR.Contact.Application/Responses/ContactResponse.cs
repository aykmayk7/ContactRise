using CR.Contact.Application.Commands.Create;
using System;
using System.Collections.Generic;

namespace CR.Contact.Application.Responses
{
    public class ContactResponse : BaseResponse
    {
        public Guid ContactId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public IEnumerable<ContactInfosResponse> ContactInfos { get; set; }
    }
}
