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
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserCommandHandle(IUserRepository userService, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmailAsync(request.LoginUserRequest.Email);

            if (user == null)
            {
                throw new UserNotFoundException(user.Id);
            }

            if (!_passwordHasher.VerifyPassword(user.Password, request.LoginUserRequest.Password))
            {
                throw new InvalidPasswordException();
            }
            return _tokenService.GenerateToken(user);
        }
    }
}
