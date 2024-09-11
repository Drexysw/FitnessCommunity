using FitnessCommunity.Application.Dtos.UserDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class UpdateUserCommand : BaseUserRequest, IRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

    }
}
