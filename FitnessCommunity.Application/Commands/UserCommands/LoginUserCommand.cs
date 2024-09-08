using FitnessCommunity.Application.Dtos.UserDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class LoginUserCommand(LoginUserRequest loginUserRequest) : IRequest<string>
    {
        public LoginUserRequest LoginUserRequest { get; } = loginUserRequest;
    }
}
