using FitnessCommunity.Domain.Enums.Workout;

namespace FitnessCommunity.Application.Dtos.WorkoutDtos.Base
{
    public class BaseWorkoutRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkoutType Type { get; set; }
        public WorkoutLevel Level { get; set; }
    }
}
