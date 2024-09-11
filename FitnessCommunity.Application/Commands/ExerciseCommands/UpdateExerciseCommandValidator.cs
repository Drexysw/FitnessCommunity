using FitnessCommunity.Application.Commands.ExerciseCommands.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public sealed class UpdateExerciseCommandValidator : BaseExerciseValidator<UpdateExerciseCommand>
    {
        public UpdateExerciseCommandValidator()
        {
            IdRules();
        }
        private void IdRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Exercise Id must not be empty");
        }
    }
}
