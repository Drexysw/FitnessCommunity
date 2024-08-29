using FitnessCommunity.Domain.Enums.Workout;

namespace FitnessCommunity.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkoutType Type { get; set; }
        public WorkoutLevel Level { get; set; }
        public List<Exercise> Exercises { get; set; } = [];
    }
}
