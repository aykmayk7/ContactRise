using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Queries.SingleQuery
{

    public record ContactQuery(Guid Id) : IRequest<ApiResponse<ContactResponse>>;

}