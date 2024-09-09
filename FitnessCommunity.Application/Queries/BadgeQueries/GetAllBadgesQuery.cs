using FitnessCommunity.Application.Dtos.BadgeDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.BadgeQueries
{
    public class GetAllBadgesQuery : IRequest<IEnumerable<GetAllBadgesResponse>>
    {
    }
}
