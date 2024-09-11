using FitnessCommunity.Application.Dtos.WorkoutDtos.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class CreateWorkoutCommand : BaseWorkoutRequest, IRequest<Unit>
    {
    }
}
