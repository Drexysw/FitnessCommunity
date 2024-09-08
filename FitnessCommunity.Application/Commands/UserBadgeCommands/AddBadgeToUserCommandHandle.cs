using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using FitnessCommunity.Domain.Exceptions.UserBadgesExceptions;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserBadgeCommands
{
    public class AddBadgeToUserCommandHandle : IRequestHandler<AddBadgeToUserCommand, Unit>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddBadgeToUserCommandHandle(IUnitOfWork unitOfWork, IBadgeRepository badgeRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _badgeRepository = badgeRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddBadgeToUserCommand request, CancellationToken cancellationToken)
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
            if (user.UserBadges.Any(bu => bu.BadgeId == request.BadgeId))
            {
                throw new UserAlreadyHasBadgeException(user.Username);
            }

            user.UserBadges.Add(new UserBadge
            {
                UserId = request.BadgeId,
                BadgeId = request.UserId
            });
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}