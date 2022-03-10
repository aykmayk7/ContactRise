using CR.Core;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Responses
{
    public class ContactInfosResponse : BaseResponse
    {

        public string ContactId { get; set; }

        public ContactInfoEnum Info { get; set; }

        public string InfoName { get { return Enumerations.GetEnumDescription(Info); } }

        public string Value { get; set; }

        public string Contents { get; set; }


    }
}
