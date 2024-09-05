using MediatR;

namespace FitnessCommunity.Application.Commands.UserBadgeCommands
{
    public class AddBadgeToUserCommand(Guid userId, Guid badgeId) : IRequest<Unit>
    {
        public Guid UserId { get; } = userId;
        public Guid BadgeId { get; } = badgeId;
    }
}
