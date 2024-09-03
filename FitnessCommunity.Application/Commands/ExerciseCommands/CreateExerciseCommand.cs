using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class CreateExerciseCommand(CreateExerciseRequest createExerciseRequest) : IRequest<CreateExerciseRequest>
    {
        public CreateExerciseRequest CreateExerciseRequest { get; } = createExerciseRequest;
    }
}
