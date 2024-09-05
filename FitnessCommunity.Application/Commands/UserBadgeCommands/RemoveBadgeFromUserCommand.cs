using MediatR;

namespace FitnessCommunity.Application.Commands.UserBadgeCommands
{
    public class RemoveBadgeFromUserCommand(Guid userId, Guid badgeId) : IRequest<Unit>
    {
        public Guid UserId { get; } = userId;
        public Guid BadgeId { get; } = badgeId;
    }
}
