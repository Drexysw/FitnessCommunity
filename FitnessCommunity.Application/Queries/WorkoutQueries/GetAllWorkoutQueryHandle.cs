using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos.Responses;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.WorkoutQueries
{
    public class GetAllWorkoutQueryHandle(IMapper mapper, IWorkoutRepository workoutRepository)
        : IRequestHandler<GetAllWorkoutQuery, IEnumerable<GetAllWorkoutResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IWorkoutRepository _workoutRepository = workoutRepository;

        public async Task<IEnumerable<GetAllWorkoutResponse>> Handle(GetAllWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllWorkoutResponse>>(workouts);
        }
    }
}
