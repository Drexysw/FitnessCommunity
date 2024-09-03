using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Responses;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.ExerciseQueries
{
    public class GetByIdExerciseQueryHandle(IExerciseRepository exerciseRepository,IMapper mapper)
        : IRequestHandler<GetByIdExerciseQuery, GetByIdExerciseResponse>
    {
        public readonly IExerciseRepository _exerciseRepository = exerciseRepository;
        public readonly IMapper _mapper = mapper;

        public async Task<GetByIdExerciseResponse> Handle(GetByIdExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(request.Id);
            }
            return _mapper.Map<GetByIdExerciseResponse>(exercise);
        }
    }
}
