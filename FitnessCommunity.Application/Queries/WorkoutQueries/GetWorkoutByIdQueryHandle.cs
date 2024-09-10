using AutoMapper;
using FitnessCommunity.Application.Dtos.WorkoutDtos.Responses;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.WorkoutQueries
{
    public class GetWorkoutByIdQueryHandle(IMapper mapper, IWorkoutRepository workoutRepository)
        : IRequestHandler<GetWorkoutByIdQuery, GetWorkoutByIdResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IWorkoutRepository _workoutRepository = workoutRepository;

        public async Task<GetWorkoutByIdResponse> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.WorkoutId);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(workout.Id);
            }
            return _mapper.Map<GetWorkoutByIdResponse>(workout);
        }
    }
}
