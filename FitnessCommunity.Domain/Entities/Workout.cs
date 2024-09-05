using System.ComponentModel.DataAnnotations;
using FitnessCommunity.Domain.Enums.Workout;

namespace FitnessCommunity.Domain.Entities
{
    public class Workout : BaseEntity.BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkoutType Type { get; set; }
        public WorkoutLevel Level { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = [];
        public ICollection<UserWorkout> LikedByUsers { get; set; } = [];

    }
}
