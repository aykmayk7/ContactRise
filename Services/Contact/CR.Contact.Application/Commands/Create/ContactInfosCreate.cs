﻿using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactInfosCreate : IRequest<ApiResponse<ContactInfosResponse>>
    {
        public Guid Id { get; set; }

        public string ContactId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }


    }
}
