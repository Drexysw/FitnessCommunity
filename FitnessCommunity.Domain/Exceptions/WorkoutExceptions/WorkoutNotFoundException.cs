namespace FitnessCommunity.Domain.Exceptions.WorkoutExceptions
{
    public class WorkoutNotFoundException(Guid Id) : Exception($"Workout with {Id} not found ");
}
