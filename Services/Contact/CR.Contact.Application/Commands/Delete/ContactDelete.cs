using CR.Contact.Application.Responses;
using CR.Core.Responses;
using MediatR;
using System;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactDelete(string Id) : IRequest<ApiResponse<bool>>;
}
