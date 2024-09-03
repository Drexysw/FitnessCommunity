using AutoMapper;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class DeleteWorkoutCommandHandle(
        IWorkoutRepository workoutRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository = workoutRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.WorkoutId);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(request.WorkoutId);
            }
            workoutRepository.Delete(workout);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
