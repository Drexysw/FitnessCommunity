namespace FitnessCommunity.Domain.Exceptions
{
    public class ExerciseNotFoundException(Guid id) : Exception($"Exercise with id {id} was not found.");
}
