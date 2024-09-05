using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutExerciseCommands
{
    public class AddExerciseToWorkoutCommand(Guid workoutId, Guid exerciseId) : IRequest<Unit>
    {
        public Guid WorkoutId { get; set; } = workoutId;
        public Guid ExerciseId { get; set; } = exerciseId;
    }
}
