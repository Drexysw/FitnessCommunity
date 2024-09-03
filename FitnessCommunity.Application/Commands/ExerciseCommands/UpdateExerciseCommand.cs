using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommand(UpdateExerciseRequest updateExerciseRequest) : IRequest<UpdateExerciseRequest>
    {
        public UpdateExerciseRequest UpdateExerciseRequest { get;} = updateExerciseRequest;
    }
}
