﻿using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Commands.Create
{
    public class ContactCreate : IRequest<ApiResponse<ContactCreate>>
    {   
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

    }
}
