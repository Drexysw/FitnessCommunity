using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class DeleteWorkoutCommand(Guid id) : IRequest
    {
        public Guid WorkoutId { get; set; } = id;
    }
}
