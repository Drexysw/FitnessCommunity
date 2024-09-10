using FitnessCommunity.Domain.Enums.ExerciseEnums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class CreateExerciseCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
