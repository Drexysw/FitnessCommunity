using AutoMapper;
using FitnessCommunity.Application.Dtos.BadgeDtos.Responses;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.BadgeQueries
{
    public sealed class GetBadgeByIdQueryHandle : IRequestHandler<GetBadgeByIdQuery, GetBadgeByIdResponse>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IMapper _mapper;
        public GetBadgeByIdQueryHandle(IBadgeRepository badgeRepository, IMapper mapper)
        {
            _badgeRepository = badgeRepository;
            _mapper = mapper;
        }
        public async Task<GetBadgeByIdResponse> Handle(GetBadgeByIdQuery request, CancellationToken cancellationToken)
        {
            var badge = await _badgeRepository.GetByIdAsync(request.Id);
            if (badge == null)
            {
                throw new BadgeNotFoundException(request.Id);
            }
            var badgeResponse = _mapper.Map<GetBadgeByIdResponse>(badge);
            return badgeResponse;
        }
    }
}
