using FitnessCommunity.Application.Dtos.UserDtos.Requests.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.UserCommands.Base
{
    public abstract class BaseUserValidator<T> : AbstractValidator<T> where T : BaseUserRequest
    {
        protected BaseUserValidator()
        {
            EmailRules();
            PasswordRules();
        }

        private void EmailRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Emails must not be empty")
                .EmailAddress().WithMessage("Enter a valid email address");
        }

        private void PasswordRules()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
        }
    }
}
