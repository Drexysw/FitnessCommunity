using FitnessCommunity.Domain.Dtos.ExerciseDtos.Responses;
using MediatR;

namespace FitnessCommunity.Application.Queries.ExerciseQueries
{
    public class GetByIdExerciseQuery(Guid id) : IRequest<GetByIdExerciseResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
