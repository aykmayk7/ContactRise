using CR.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Aggregator.Models
{
    public class ContactResponse : IRequest<ApiResponse<ContactResponse>>
    {
        public string Location { get; set; }

        public int PersonCnt { get; set; }

        public int TelephoneCnt { get; set; }
    }
}
