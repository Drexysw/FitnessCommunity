namespace FitnessCommunity.Domain.Exceptions.ExcerciseExceptions
{
    public class ExerciseNotFoundException(Guid id) : Exception($"Exercise with id {id} was not found.");
}
