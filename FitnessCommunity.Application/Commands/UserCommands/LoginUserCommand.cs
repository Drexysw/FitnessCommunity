using FitnessCommunity.Application.Dtos.UserDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
