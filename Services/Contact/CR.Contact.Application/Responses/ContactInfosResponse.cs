using CR.Contact.Application.Commands.Create;
using System.Collections.Generic;

namespace CR.Contact.Application.Responses
{
    public class ContactInfosResponse : BaseResponse
    {
        public int ContactId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }

        public ICollection<ContactCreate> Items { get; set; }

    }
}
