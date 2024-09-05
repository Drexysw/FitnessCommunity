using AutoMapper;
using FitnessCommunity.Application.Dtos.BadgeDtos;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class UpdateBadgeCommandHandle(IMapper mapper, IUnitOfWork unitOfWork, IBadgeRepository badgeRepository)
        : IRequestHandler<UpdateBadgeCommand, UpdateBadgeRequest>
    {
        public async Task<UpdateBadgeRequest> Handle(UpdateBadgeCommand request, CancellationToken cancellationToken)
        {
            var badge = await badgeRepository.GetByIdAsync(request.UpdateBadgeRequest.Id);
            if (badge == null)
            {
                throw new BadgeNotFoundException(badge.Id);
            }
            badge = mapper.Map<Badge>(request.UpdateBadgeRequest);
            badgeRepository.UpdateAsync(badge);
            await unitOfWork.SaveChangesAsync();
            return request.UpdateBadgeRequest;
        }
    }
}
