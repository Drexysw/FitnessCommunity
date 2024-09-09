using FitnessCommunity.Application.Dtos.BadgeDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class UpdateBadgeCommand(UpdateBadgeRequest updateBadgeRequest) : IRequest<UpdateBadgeRequest>
    {
        public Guid Id { get; set; }
        public UpdateBadgeRequest UpdateBadgeRequest { get; set; } = updateBadgeRequest;
    }
}
