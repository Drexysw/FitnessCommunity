using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class DeleteUserCommand(Guid id) : IRequest
    {
        public Guid UserId { get; set; } = id;
    }
}
