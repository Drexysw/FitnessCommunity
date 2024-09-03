using FitnessCommunity.Application.Dtos.WorkoutDtos;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class CreateWorkoutCommand(CreateWorkoutRequest createWorkoutRequest) : IRequest<CreateWorkoutRequest>
    {
        public CreateWorkoutRequest CreateWorkoutRequest { get; } = createWorkoutRequest; 

    }
}
