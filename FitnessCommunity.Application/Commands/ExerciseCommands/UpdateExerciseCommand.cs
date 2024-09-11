using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommand : BaseExerciseRequest, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
