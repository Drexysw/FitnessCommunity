using AutoMapper;
using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class RegisterUserCommandHandle(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        : IRequestHandler<RegisterUserCommand, Unit>
    {
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request.RegisterUserRequest);
            user.Password = passwordHasher.HashPassword(user.Password);
            await userRepository.AddUserAsync(user);
            await unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
