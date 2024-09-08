using FitnessCommunity.Application.Dtos.UserDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class RegisterUserCommand(RegisterUserRequest registerUserRequest)
        : IRequest<Unit>
    {
        public RegisterUserRequest RegisterUserRequest { get; set; } = registerUserRequest;
    }
}
