using CR.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Report.Aggregator.Models
{
    public class ContactCreate : IRequest<ApiResponse<ContactCreate>>
    {
        public Guid ContactId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public IEnumerable<ContactInfosCreate> ContactInfos { get; set; }
    }
}