using CR.Core;
using System;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Responses
{
    public class ContactInfosResponse : BaseResponse
    {
        public Guid ContactId { get; set; }

        public ContactInfoEnum Info { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }

        public ContactResponse ContactResponse { get; set; }

    }
}
