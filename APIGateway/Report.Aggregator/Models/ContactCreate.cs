using CR.Core.Responses;
using MediatR;

namespace Report.Aggregator.Models
{
    public class ContactCreate : IRequest<ApiResponse<ContactCreate>>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }
    }
}
