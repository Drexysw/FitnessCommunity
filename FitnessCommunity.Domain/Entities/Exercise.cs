using System.ComponentModel.DataAnnotations;

namespace FitnessCommunity.Domain.Entities
{
    public class Exercise : BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(65)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string VideoUrl { get; set; } = string.Empty;
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public string MuscleGroup { get; set; } = string.Empty;
        public ICollection<WorkoutExercise> Workouts { get; set; } = [];
    }
}
