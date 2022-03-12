using CR.Contact.Application.Commands.Create;
using System.Collections.Generic;

namespace CR.Contact.Application.Responses
{
    public class ContactResponse : BaseResponse
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public List<ContactInfosCreate> ContactInfo { get; set; }


    }
}
