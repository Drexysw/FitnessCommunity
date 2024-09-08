using FitnessCommunity.Application.Dtos.UserDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.UserQueries
{
    public class GetUserByIdQuery(Guid id) : IRequest<GetUserDetailsByIdResponse>
    {
        public Guid Id { get; } = id;
    }
}
