using AutoMapper;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class CreateBadgeCommandHandle : IRequestHandler<CreateBadgeCommand, Guid>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBadgeCommandHandle(IBadgeRepository badgeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _badgeRepository = badgeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = _mapper.Map<Badge>(request);
            await _badgeRepository.AddAsync(badge);
            await _unitOfWork.SaveChangesAsync();
            return badge.Id;
        }
    }
}
