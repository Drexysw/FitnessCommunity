using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class CreateWorkoutCommandHandle(
        IWorkoutRepository workoutRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateWorkoutCommand, CreateWorkoutRequest>
    {
        private readonly IWorkoutRepository _workoutRepository = workoutRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateWorkoutRequest> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = _mapper.Map<Workout>(request.CreateWorkoutRequest);
            await _workoutRepository.AddAsync(workout);
            await _unitOfWork.SaveChangesAsync();
            return request.CreateWorkoutRequest;
        }
    }
}
