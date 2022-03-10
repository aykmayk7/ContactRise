using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Report.Application.Commands.Create
{
    public class ReportInfoCreate : IRequest<ApiResponse<ReportInfoCreate>>
    {
        public ReportInfoCreate()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id{ get; set; }

        public string Location { get; set; }
        public int PersonCount{ get; set; }
        public int TelephoneCount{ get; set; }
    }
}
