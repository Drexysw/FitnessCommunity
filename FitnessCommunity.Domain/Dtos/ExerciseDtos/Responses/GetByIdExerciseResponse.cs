namespace FitnessCommunity.Domain.Dtos.ExerciseDtos.Responses
{
    public class GetByIdExerciseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public string MuscleGroup { get; set; } = string.Empty;
    }
}
