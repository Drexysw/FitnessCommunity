using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests.Base;
using FluentValidation;

namespace FitnessCommunity.Application.Commands.ExerciseCommands.Base
{
    public abstract class BaseExerciseValidator<T> : AbstractValidator<T> where T : BaseExerciseRequest
    {
        protected BaseExerciseValidator()
        {
            NameRules();
            DescriptionRules();
            Sets();
            Repetitions();
            MuscleGroup();
            VideoUrl();
        }
        private void NameRules()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .MaximumLength(70).WithMessage("Name must not exceed 70 characters")
                .MinimumLength(3).WithMessage("Name must be more than 3 characters");
        }
        private void DescriptionRules()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description must not be empty")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters")
                .MinimumLength(10).WithMessage("Description must be more than 10 characters");
        }
        private void Sets()
        {
            RuleFor(c => c.Sets)
                .GreaterThan(0).WithMessage("Sets must be greater than 0");
        }
        private void Repetitions()
        {
            RuleFor(c => c.Repetitions)
                .GreaterThan(0).WithMessage("Repetitions must be greater than 0");
        }
        private void MuscleGroup()
        {
            RuleFor(c => c.MuscleGroup)
                .NotEmpty().WithMessage("Exercise must contain muscle group")
                .IsInEnum();
        }
        private void VideoUrl()
        {
            RuleFor(c => c.VideoUrl)
                .NotEmpty().WithMessage("Video URL must not be empty");
        }
    }
}
