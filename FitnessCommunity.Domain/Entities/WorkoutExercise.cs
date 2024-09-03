using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessCommunity.Domain.Entities
{
    public class WorkoutExercise
    {
        public Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }
        public Guid ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }
        public int Order { get; set; }
    }
}
