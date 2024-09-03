using System.ComponentModel.DataAnnotations;

namespace FitnessCommunity.Domain.Dtos.ExerciseDtos.Responses
{
    public class GetAllExerciseResponse  
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        public string VideoUrl { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
    }
}
