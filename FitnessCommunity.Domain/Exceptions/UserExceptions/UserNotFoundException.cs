namespace FitnessCommunity.Domain.Exceptions.UserExceptions
{
    public class UserNotFoundException(Guid id) : Exception($"User with id {id} was not found.");
}
