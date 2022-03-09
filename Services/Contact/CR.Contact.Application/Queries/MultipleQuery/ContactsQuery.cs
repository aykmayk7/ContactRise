using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CR.Contact.Application.Queries.MultipleQuery
{
    public record ContactsQuery(Expression<Func<ContactCreate, bool>> Predicate = null) : IRequest<ApiResponse<IEnumerable<ContactResponse>>>;
}
