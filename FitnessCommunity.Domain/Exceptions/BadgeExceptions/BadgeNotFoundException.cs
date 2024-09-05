namespace FitnessCommunity.Domain.Exceptions.BadgeExceptions
{
    public class BadgeNotFoundException(Guid id) : Exception($"Badge with id {id} was not found.");
}
