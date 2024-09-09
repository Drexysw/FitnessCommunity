using AutoMapper;
using FitnessCommunity.Application.Dtos.BadgeDtos.Responses;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.BadgeQueries
{
    public sealed class GetAllBadgesQueryHandle : IRequestHandler<GetAllBadgesQuery, IEnumerable<GetAllBadgesResponse>>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IMapper _mapper;
        public GetAllBadgesQueryHandle(IBadgeRepository badgeRepository, IMapper mapper)
        {
            _badgeRepository = badgeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllBadgesResponse>> Handle(GetAllBadgesQuery request, CancellationToken cancellationToken)
        {
            var badges = await _badgeRepository.GetAllAsync();
            var badgesResponse = _mapper.Map<IEnumerable<GetAllBadgesResponse>>(badges);
            return badgesResponse;
        }
    }
}
