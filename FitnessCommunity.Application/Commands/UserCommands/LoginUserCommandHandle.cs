using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Exceptions.PasswordExceptions;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public class LoginUserCommandHandle : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userService;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserCommandHandle(IUserRepository userService, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UserNotFoundException(user.Id);
            }

            if (!_passwordHasher.VerifyPassword(user.Password, request.Password))
            {
                throw new InvalidPasswordException();
            }
            return _jwtProvider.GenerateJwtToken(user);
        }
    }
}
