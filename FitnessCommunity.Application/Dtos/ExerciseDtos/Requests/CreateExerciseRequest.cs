using System.ComponentModel.DataAnnotations;
using FitnessCommunity.Domain.Enums.ExerciseEnums;

namespace FitnessCommunity.Application.Dtos.ExerciseDtos.Requests
{
    public class CreateExerciseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Url]
        public string VideoUrl { get; set; } = string.Empty;

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
    }
}
