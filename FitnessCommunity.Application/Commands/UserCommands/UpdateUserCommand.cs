using FitnessCommunity.Application.Dtos.UserDtos;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
