using CR.Contact.Application.Commands.Create;
using CR.Core.Responses;
using MediatR;
using System;
using System.Linq.Expressions;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactDelete(string id) : IRequest<ApiResponse>;
}
