namespace FitnessCommunity.Domain.Entities
{
    public class Badge : BaseEntity.BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string IconUrl { get; set; } = string.Empty;
        public int WorkoutsRequired { get; set; } 
        public ICollection<UserBadge> UserBadges { get; set; } = [];
    }
}
