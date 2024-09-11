using FitnessCommunity.Domain.Enums.ExerciseEnums;

namespace FitnessCommunity.Application.Dtos.ExerciseDtos.Requests.Base
{
    public abstract class BaseExerciseRequest
    {
        public string Name { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
