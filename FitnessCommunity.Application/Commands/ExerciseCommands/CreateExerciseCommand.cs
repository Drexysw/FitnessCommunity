using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class CreateExerciseCommand : BaseExerciseRequest, IRequest<Guid>
    {
    }
}
