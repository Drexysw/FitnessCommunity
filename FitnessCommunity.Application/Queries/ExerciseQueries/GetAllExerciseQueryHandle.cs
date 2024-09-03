using AutoMapper;
using FitnessCommunity.Domain.Dtos.ExerciseDtos.Responses;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.ExerciseQueries
{
    public class GetAllExerciseQueryHandle : IRequestHandler<GetAllExerciseQuery, IEnumerable<GetAllExerciseResponse>>
    {
        public readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public GetAllExerciseQueryHandle(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<IEnumerable<GetAllExerciseResponse>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllExerciseResponse>>(exercises);
        }
    }
}
