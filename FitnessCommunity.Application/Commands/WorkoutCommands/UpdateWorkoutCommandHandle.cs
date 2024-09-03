using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class UpdateWorkoutCommandHandle(
        IWorkoutRepository workoutRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateWorkoutCommand, UpdateWorkoutRequest>
    {
        private readonly IWorkoutRepository _workoutRepository = workoutRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<UpdateWorkoutRequest> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.UpdateWorkoutRequest.Id);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(request.UpdateWorkoutRequest.Id);
            }

            var workoutToUpdate = _mapper.Map(request.UpdateWorkoutRequest, workout);
            workoutRepository.Update(workoutToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return request.UpdateWorkoutRequest;
        }
    }
}
