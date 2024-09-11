using FitnessCommunity.Application.Dtos.UserDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class LoginUserCommand : BaseUserRequest,IRequest<string>
    {
    }
}
