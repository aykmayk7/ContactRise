using CR.Core.Responses;
using MediatR;

namespace CR.Contact.Application.Commands.Delete
{
    public record ContactInfosDelete(string id, string key) : IRequest<ApiResponse>;
}
