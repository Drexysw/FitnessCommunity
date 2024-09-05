namespace FitnessCommunity.Domain.Exceptions.UserBadgesExceptions
{
    public class UserAlreadyHasBadgeException(string userName) : Exception($"User {userName} already has this badge.");
}
