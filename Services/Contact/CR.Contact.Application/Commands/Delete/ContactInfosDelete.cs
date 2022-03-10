using CR.Core.Responses;
using MediatR;
using static CR.Core.Enumerations;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactInfosDelete(string id, ContactInfoEnum key) : IRequest<ApiResponse>;
}
