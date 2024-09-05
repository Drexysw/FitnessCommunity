namespace FitnessCommunity.Domain.Exceptions.WorkoutExcerciseExceptions
{
    public class WorkoutDoesNotHaveExerciseException(Guid workoutId, Guid exerciseId)
        : Exception($"Workout with id {workoutId} does not have exercise with id {exerciseId}");
}
