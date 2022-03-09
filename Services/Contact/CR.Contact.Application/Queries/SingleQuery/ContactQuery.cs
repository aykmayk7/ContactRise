using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;
using System.Linq.Expressions;

namespace CR.Contact.Application.Queries.SingleQuery
{

    public record ContactQuery(Expression<Func<ContactCreate, bool>> Predicate) : IRequest<ApiResponse<ContactResponse>>;

}