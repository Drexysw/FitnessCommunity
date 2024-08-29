namespace FitnessCommunity.Domain.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int Duration { get; set; }
        public Guid WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;
    }
}
