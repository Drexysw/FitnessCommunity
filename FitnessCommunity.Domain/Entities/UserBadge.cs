namespace FitnessCommunity.Domain.Entities
{
    public class UserBadge
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid BadgeId { get; set; }
        public Badge Badge { get; set; } = null!;

        public DateTime EarnedDate { get; set; } = DateTime.UtcNow;
    }
}
