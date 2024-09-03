using FitnessCommunity.Domain.Enums.ExerciseEnums;
using System.ComponentModel.DataAnnotations;

namespace FitnessCommunity.Application.Dtos.ExerciseDtos.Requests
{
    public class UpdateExerciseRequest
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(65)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Url]
        public string VideoUrl { get; set; } = string.Empty;

        [Required]
        [Range(1, 12, ErrorMessage = "Sets must be greater than 0")]
        public int Sets { get; set; }

        [Required]
        [Range(1, 30, ErrorMessage = "Repetitions must be greater than 0")]
        public int Repetitions { get; set; }

        [Required]
        public MuscleGroup MuscleGroup { get; set; }
    }
}
