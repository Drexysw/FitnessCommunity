using FitnessCommunity.Application.Dtos.WorkoutDtos;
using MediatR;

namespace FitnessCommunity.Application.Queries.WorkoutQueries
{
    public class GetAllWorkoutQuery : IRequest<IEnumerable<GetAllWorkoutResponse>>
    {
    }
}
