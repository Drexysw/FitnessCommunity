using AutoMapper;
using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class UpdateUserCommandHandle : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public UpdateUserCommandHandle(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException(user.Id);
            }

            var newUser = _mapper.Map<User>(request);
            newUser.Password = _passwordHasher.Hash(newUser.Password);
            await _userRepository.UpdateUser(newUser);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
