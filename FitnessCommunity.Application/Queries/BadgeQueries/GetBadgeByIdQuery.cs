using FitnessCommunity.Application.Dtos.BadgeDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.BadgeQueries
{
    public class GetBadgeByIdQuery(Guid id) : IRequest<GetBadgeByIdResponse>
    {
        public Guid Id { get; } = id;
    }
}
