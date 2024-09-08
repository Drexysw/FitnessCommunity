using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExcerciseExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutExerciseCommands
{
    public class RemoveExerciseFromWorkoutCommandHandle : IRequestHandler<RemoveExerciseFromWorkoutCommand, Unit>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveExerciseFromWorkoutCommandHandle(IWorkoutRepository workoutRepository,
            IExerciseRepository exerciseRepository,
            IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public  async Task<Unit> Handle(RemoveExerciseFromWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.WorkoutId);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(request.WorkoutId);
            }
            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(request.ExerciseId);
            }

            var workoutExercise = workout.WorkoutExercises.FirstOrDefault(we => we.ExerciseId == exercise.Id);
            if (workoutExercise == null)
            {
                throw new WorkoutDoesNotHaveExerciseException(workout.Id, exercise.Id);
            }

            workout.WorkoutExercises.Remove(workoutExercise);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
