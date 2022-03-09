using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;

namespace CR.Contact.Application.Queries.SingleQuery
{

    public record ContactInfoQuery(string id) : IRequest<ApiResponse<ContactInfosResponse>>;

}
