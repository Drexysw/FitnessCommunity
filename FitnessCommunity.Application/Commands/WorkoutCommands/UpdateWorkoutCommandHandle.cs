using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class UpdateWorkoutCommandHandle : IRequestHandler<UpdateWorkoutCommand, UpdateWorkoutRequest>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkoutCommandHandle(IWorkoutRepository workoutRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateWorkoutRequest> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.Id);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(request.Id);
            }

            var workoutToUpdate = _mapper.Map(request.UpdateWorkoutRequest, workout);
            _workoutRepository.Update(workoutToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return request.UpdateWorkoutRequest;
        }
    }
}
