namespace FitnessCommunity.Domain.Entities
{
    public class User : BaseEntity.BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<Workout> Workouts { get; set; } = [];
        public ICollection<UserBadge> UserBadges { get; set; } = [];
        public ICollection<UserWorkout> LikedWorkouts { get; set; } = [];


    }
}
