using FitnessCommunity.Application.Dtos.WorkoutDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class UpdateWorkoutCommand(UpdateWorkoutRequest updateWorkoutRequest) : IRequest<UpdateWorkoutRequest>
    {
        public UpdateWorkoutRequest UpdateWorkoutRequest { get; } = updateWorkoutRequest;
    }
}
