using FitnessCommunity.Domain.Enums.ExerciseEnums;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
