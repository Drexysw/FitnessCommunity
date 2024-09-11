using FitnessCommunity.Application.Dtos.BadgeDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class UpdateBadgeCommand() : BaseBadgeRequest, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
