using FitnessCommunity.Application.Commands.BadgeCommands.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.BadgeCommands
{
    public sealed class UpdateBadgeCommandValidator : BaseBadgeValidator<UpdateBadgeCommand>
    {
        public UpdateBadgeCommandValidator()
        {
            IdRules();
        }
        private void IdRules()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
