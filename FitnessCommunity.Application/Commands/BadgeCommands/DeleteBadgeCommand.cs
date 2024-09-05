using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class DeleteBadgeCommand(Guid id) : IRequest<Guid>
    {
        public Guid BadgeId { get; set; } = id;
    }
}
