using FitnessCommunity.Application.Dtos.WorkoutDtos.Requests;
using FitnessCommunity.Domain.Enums.Workout;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class UpdateWorkoutCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkoutType Type { get; set; }
        public WorkoutLevel Level { get; set; }
    }
}
