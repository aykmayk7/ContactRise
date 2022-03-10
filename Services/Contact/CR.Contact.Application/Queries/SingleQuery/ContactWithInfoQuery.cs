using CR.Contact.Application.Commands.Create;
using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Queries.SingleQuery
{

    public record ContactWithInfoQuery(Guid Id) : IRequest<ApiResponse<ContactWithInfoCreate>>;

}
