namespace FitnessCommunity.Domain.Exceptions
{
    public class WorkoutNotFoundException(Guid Id) : Exception($"Workout with {Id} not found ");
}
