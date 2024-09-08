using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class DeleteWorkoutCommandHandle : IRequestHandler<DeleteWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkoutRepository _workoutRepository1;

        public DeleteWorkoutCommandHandle(IWorkoutRepository workoutRepository,
            IUnitOfWork unitOfWork)
        {
            _workoutRepository1 = workoutRepository;
            _workoutRepository = workoutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.WorkoutId);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(request.WorkoutId);
            }
            _workoutRepository1.Delete(workout);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
