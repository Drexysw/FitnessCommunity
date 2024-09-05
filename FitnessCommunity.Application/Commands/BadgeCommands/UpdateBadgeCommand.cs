using FitnessCommunity.Application.Dtos.BadgeDtos;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class UpdateBadgeCommand(UpdateBadgeRequest updateBadgeRequest) : IRequest<UpdateBadgeRequest>
    {
        public UpdateBadgeRequest UpdateBadgeRequest { get; set; } = updateBadgeRequest;
    }
}
