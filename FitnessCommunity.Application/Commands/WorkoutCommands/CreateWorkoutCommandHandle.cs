using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.WorkoutCommands
{
    public class CreateWorkoutCommandHandle : IRequestHandler<CreateWorkoutCommand, Unit>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkoutCommandHandle(IWorkoutRepository workoutRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = _mapper.Map<Workout>(request);
            await _workoutRepository.AddAsync(workout);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
