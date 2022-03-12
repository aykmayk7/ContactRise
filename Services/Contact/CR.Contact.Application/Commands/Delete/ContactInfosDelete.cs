using CR.Core.Responses;
using MediatR;
using System;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactInfosDelete(Guid id, ContactInfoEnum key) : IRequest<ApiResponse>;
}
