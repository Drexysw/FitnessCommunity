using FitnessCommunity.Application.Dtos.BadgeDtos.Requests.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.BadgeCommands.Base
{
    public abstract class BaseBadgeValidator<T> : AbstractValidator<T> where T : BaseBadgeRequest
    {
        protected BaseBadgeValidator()
        {
            DescriptionRules();
            NameRules();
            WorkoutRules();
            IconRules();
        }

        private void IconRules()
        {
            RuleFor(c => c.IconUrl)
                .NotEmpty().WithMessage("Icon URL is required.");
        }

        private void DescriptionRules()
        {
            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.")
                .MinimumLength(10).WithMessage("Description length must be more than 10 characters");
        }

        private void NameRules()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("Name length must be more than 3 characters");
        }

        private void WorkoutRules()
        {
            RuleFor(c => c.WorkoutsRequired)
                .NotEmpty().WithMessage("Workouts required is required.")
                .GreaterThan(0).WithMessage("Workouts required must be greater than 0");
        }
    }
}
