﻿using CR.Core.Responses;
using MediatR;
using System;

namespace Report.Aggregator.Models
{
    public class ContactCreate : IRequest<ApiResponse<ContactCreate>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }
    }
}