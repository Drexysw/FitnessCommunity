namespace FitnessCommunity.Domain.Entities
{
    public class UserWorkout
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid WorkoutId { get; set; }
        public Workout Workout { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }
}
