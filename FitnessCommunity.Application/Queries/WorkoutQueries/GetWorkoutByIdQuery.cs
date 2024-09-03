using FitnessCommunity.Application.Dtos.WorkoutDtos;
using MediatR;

namespace FitnessCommunity.Application.Queries.WorkoutQueries
{
    public class GetWorkoutByIdQuery(Guid id) : IRequest<GetWorkoutByIdResponse>
    {
        public Guid WorkoutId { get; set; } = id;
    }
}
