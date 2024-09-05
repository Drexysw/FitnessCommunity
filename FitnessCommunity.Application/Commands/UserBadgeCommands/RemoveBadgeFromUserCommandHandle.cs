using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using FitnessCommunity.Domain.Exceptions.UserBadgesExceptions;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserBadgeCommands
{
    public class RemoveBadgeFromUserCommandHandle(
        IBadgeRepository badgeRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveBadgeFromUserCommand, Unit>
    {
        private readonly IBadgeRepository _badgeRepository = badgeRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(RemoveBadgeFromUserCommand request, CancellationToken cancellationToken)
        {
            var badge = await _badgeRepository.GetByIdAsync(request.BadgeId);
            if (badge == null)
            {
                throw new BadgeNotFoundException(badge.Id);
            }
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new UserNotFoundException(user.Id);
            }
            var userBadge = user.UserBadges.FirstOrDefault(bu => bu.BadgeId == request.BadgeId);
            if (userBadge == null)
            {
                throw new UserDoesNotHaveBadgeException(user.Username);
            }

            user.UserBadges.Remove(userBadge);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
