using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class DeleteBadgeCommandHandle(IBadgeRepository badgeRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteBadgeCommand, Guid>
    {
        private readonly IBadgeRepository _badgeRepository = badgeRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(DeleteBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = await _badgeRepository.GetByIdAsync(request.Id);
            if (badge == null)
            {
                throw new BadgeNotFoundException(request.Id);
            }
            _badgeRepository.DeleteAsync(badge);
            await _unitOfWork.SaveChangesAsync();
            return badge.Id;
        }
    }
}
