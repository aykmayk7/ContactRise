using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactInfosCreate : BaseResponse
    {
        //public Guid ContactId { get { return ContactId; } set { ContactId = Id; } }
        public Guid ContactId { get; set; }

        public ContactInfoEnum Info { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }


    }
}
