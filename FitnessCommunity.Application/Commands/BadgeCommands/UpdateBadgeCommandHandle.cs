using AutoMapper;
using FitnessCommunity.Application.Dtos.BadgeDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class UpdateBadgeCommandHandle : IRequestHandler<UpdateBadgeCommand, UpdateBadgeRequest>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBadgeRepository _badgeRepository;

        public UpdateBadgeCommandHandle(IMapper mapper, IUnitOfWork unitOfWork, IBadgeRepository badgeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _badgeRepository = badgeRepository;
        }

        public async Task<UpdateBadgeRequest> Handle(UpdateBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = await _badgeRepository.GetByIdAsync(request.Id);
            if (badge == null)
            {
                throw new BadgeNotFoundException(badge.Id);
            }
            badge = _mapper.Map<Badge>(request.UpdateBadgeRequest);
            _badgeRepository.UpdateAsync(badge);
            await _unitOfWork.SaveChangesAsync();
            return request.UpdateBadgeRequest;
        }
    }
}
