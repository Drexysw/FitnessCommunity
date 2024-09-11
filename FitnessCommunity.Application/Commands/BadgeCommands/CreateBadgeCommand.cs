using FitnessCommunity.Application.Dtos.BadgeDtos.Requests.Base;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class CreateBadgeCommand : BaseBadgeRequest, IRequest<Guid>
    {
    }
}
    