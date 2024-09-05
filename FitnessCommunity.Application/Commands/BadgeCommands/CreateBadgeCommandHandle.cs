using AutoMapper;
using FitnessCommunity.Application.Dtos.BadgeDtos;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class CreateBadgeCommandHandle(IBadgeRepository badgeRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateBadgeCommand, CreateBadgeRequest>
    {
        private readonly IBadgeRepository _badgeRepository = badgeRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<CreateBadgeRequest> Handle(CreateBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = _mapper.Map<Badge>(request.CreateBadgeRequest);
            await _badgeRepository.AddAsync(badge);
            await _unitOfWork.SaveChangesAsync();
            return request.CreateBadgeRequest;
        }
    }
}
