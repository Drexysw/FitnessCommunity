using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutExerciseCommands
{
    public class RemoveExerciseFromWorkoutCommand(Guid workoutId, Guid exerciseId) : IRequest<Unit>
    {
        public Guid WorkoutId { get; } = workoutId;
        public Guid ExerciseId { get; } = exerciseId;
    }
}
