using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class DeleteExerciseCommand(Guid id) : IRequest
    {
        public Guid ExerciseId { get; } = id;
    }
}
