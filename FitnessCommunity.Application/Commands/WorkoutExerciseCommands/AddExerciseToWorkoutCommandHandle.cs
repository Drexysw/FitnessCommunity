using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExcerciseExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutExerciseCommands
{
    public class AddExerciseToWorkoutCommandHandle : IRequestHandler<AddExerciseToWorkoutCommand, Unit>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddExerciseToWorkoutCommandHandle(IWorkoutRepository workoutRepository,
            IExerciseRepository exerciseRepository,
            IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddExerciseToWorkoutCommand request, CancellationToken cancellationToken)
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

            if (workout.WorkoutExercises.Any(we => we.ExerciseId == exercise.Id))
            {
                throw new ExerciseAlreadyAddedToWorkoutException(workout.Id, exercise.Id);
            }
            workout.WorkoutExercises.Add(new WorkoutExercise
            {
                WorkoutId = workout.Id,
                ExerciseId = exercise.Id
            });
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
