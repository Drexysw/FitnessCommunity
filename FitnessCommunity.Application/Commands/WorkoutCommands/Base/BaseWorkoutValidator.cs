using FitnessCommunity.Application.Dtos.WorkoutDtos.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.WorkoutCommands.Base
{
    public abstract class BaseWorkoutValidator<T> : AbstractValidator<T> where T : BaseWorkoutRequest
    {
        protected  BaseWorkoutValidator()
        {
            NameRules();
            DescriptionRules();
            TypeRules();
            LevelRules();
        }
        private void LevelRules()
        {
            RuleFor(c => c.Level)
                .NotEmpty().WithMessage("Level must not be empty")
                .IsInEnum();
        }

        private void TypeRules()
        {
            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Type must not be empty")
                .IsInEnum();
        }

        private void DescriptionRules()
        {
            RuleFor(c => c.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters")
                .MinimumLength(10).WithMessage("Description must be more than 10 characters");
        }

        private void NameRules()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .MaximumLength(70).WithMessage("Name must not exceed 70 characters")
                .MinimumLength(3).WithMessage("Name must be more than 3 characters");
        }
    }
}
