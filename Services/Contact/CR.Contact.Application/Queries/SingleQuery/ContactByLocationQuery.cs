using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;

namespace CR.Contact.Application.Queries.SingleQuery
{

    public record ContactByLocationQuery(string LocationName) : IRequest<ApiResponse<ContactByLocationResponse>>;

}
