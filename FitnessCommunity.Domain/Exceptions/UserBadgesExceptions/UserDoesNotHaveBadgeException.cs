namespace FitnessCommunity.Domain.Exceptions.UserBadgesExceptions
{
    public class UserDoesNotHaveBadgeException(string username)
        : Exception($"User {username} does not have this badge.");
}
