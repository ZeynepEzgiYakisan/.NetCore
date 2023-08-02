using MediatR;

namespace UdemyJwtApp.Back.Core.Application.Features.CQRS.Command
{
    public class RegisterUserCommandRequest : IRequest
    {
        public string? UserName { get; set;}

        public string? Password { get; set;}
    }
}
