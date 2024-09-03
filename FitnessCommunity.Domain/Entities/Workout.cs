using System.ComponentModel.DataAnnotations;
using FitnessCommunity.Domain.Enums.Workout;

namespace FitnessCommunity.Domain.Entities
{
    public class Workout : BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public WorkoutType Type { get; set; }
        public WorkoutLevel Level { get; set; }
        public ICollection<WorkoutExercise> Exercises { get; set; } = [];
    }
}
