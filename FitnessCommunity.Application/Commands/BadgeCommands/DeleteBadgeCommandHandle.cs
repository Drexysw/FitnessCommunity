using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class DeleteBadgeCommandHandle : IRequestHandler<DeleteBadgeCommand, Guid>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBadgeCommandHandle(IBadgeRepository badgeRepository, IUnitOfWork unitOfWork)
        {
            _badgeRepository = badgeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = await _badgeRepository.GetByIdAsync(request.BadgeId);
            if (badge == null)
            {
                throw new BadgeNotFoundException(request.BadgeId);
            }
            _badgeRepository.DeleteAsync(badge);
            await _unitOfWork.SaveChangesAsync();
            return badge.Id;
        }
    }
}
