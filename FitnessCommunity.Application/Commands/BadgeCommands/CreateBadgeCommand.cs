using FitnessCommunity.Application.Dtos.BadgeDtos.Requests;
using MediatR;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public class CreateBadgeCommand(CreateBadgeRequest createBadgeRequest) : IRequest<CreateBadgeRequest>
    {
        public CreateBadgeRequest CreateBadgeRequest { get; set; } = createBadgeRequest;
    }
}
    