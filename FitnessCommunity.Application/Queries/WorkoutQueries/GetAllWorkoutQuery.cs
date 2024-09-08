using FitnessCommunity.Application.Dtos.WorkoutDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.WorkoutQueries
{
    public class GetAllWorkoutQuery : IRequest<IEnumerable<GetAllWorkoutResponse>>
    {
    }
}
