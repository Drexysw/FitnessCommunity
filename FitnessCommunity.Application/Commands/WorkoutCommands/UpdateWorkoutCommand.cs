using FitnessCommunity.Application.Dtos.WorkoutDtos.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class UpdateWorkoutCommand : BaseWorkoutRequest, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
