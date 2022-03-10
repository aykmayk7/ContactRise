using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactDelete(Guid Id) : IRequest<ApiResponse>;
}
