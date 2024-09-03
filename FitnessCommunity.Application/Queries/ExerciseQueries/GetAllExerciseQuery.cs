using FitnessCommunity.Domain.Dtos.ExerciseDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.ExerciseQueries
{
    public class GetAllExerciseQuery : IRequest<IEnumerable<GetAllExerciseResponse>>
    {
    }
}
