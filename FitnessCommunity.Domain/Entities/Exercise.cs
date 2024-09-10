using System.ComponentModel.DataAnnotations;
using FitnessCommunity.Domain.Enums.ExerciseEnums;

namespace FitnessCommunity.Domain.Entities
{
    public class Exercise : BaseEntity.BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public MuscleGroup MuscleGroup { get; set; } 
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = [];
    }
}
