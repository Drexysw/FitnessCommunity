using FitnessCommunity.Application.Commands.UserCommands.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.UserCommands
{
    public sealed class RegisterUserCommandValidator : BaseUserValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            FirstNameRules();
            LastNameRules();
            BioRules();
            UsernameRules();
        }

        private void UsernameRules()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username must not be empty.")
                .MinimumLength(2).WithMessage("Username must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");
        }

        private void BioRules()
        {
            RuleFor(x => x.Bio)
                .MaximumLength(250).WithMessage("Bio must not exceed 250 characters.");
        }


        private void LastNameRules()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name must not be empty.")
                .Matches(@"^[A-Z][a-zA-Z]*$").WithMessage("First name must start with an uppercase letter followed by lowercase letters.")
                .MaximumLength(70).WithMessage("Last name must not exceed 70 characters.")
                .MinimumLength(2).WithMessage("Last name must be longer than 2 characters.");
        }


        private void FirstNameRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name must not be empty")
                .Matches(@"^[A-Z][a-zA-Z]*$").WithMessage("First name must start with an uppercase letter followed by lowercase letters.")
                .MaximumLength(70).WithMessage("First name must not exceed 70 characters.")
                .MinimumLength(2).WithMessage("First name must be longer than 2 characters.");
        }
    }
}
