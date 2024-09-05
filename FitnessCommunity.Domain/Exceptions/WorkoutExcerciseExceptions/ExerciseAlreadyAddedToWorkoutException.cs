namespace FitnessCommunity.Domain.Exceptions.WorkoutExcerciseExceptions
{
    public class ExerciseAlreadyAddedToWorkoutException(Guid workoutId, Guid exerciseId)
        : Exception($"Exercise with id {exerciseId} is already added to workout with id {workoutId}");
}
