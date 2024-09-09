using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Responses;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.ExerciseQueries
{
    public class GetAllExerciseQueryHandle : IRequestHandler<GetAllExerciseQuery, IEnumerable<GetAllExerciseResponse>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public GetAllExerciseQueryHandle(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllExerciseResponse>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllExerciseResponse>>(exercises);
        }
    }
}
