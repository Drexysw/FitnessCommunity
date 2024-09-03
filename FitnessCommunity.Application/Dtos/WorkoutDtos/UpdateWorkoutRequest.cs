namespace FitnessCommunity.Application.Dtos.WorkoutDtos
{
    public class UpdateWorkoutRequest : Base.BaseWorkoutDto
    {
        public Guid Id { get; set; }
    }
}
