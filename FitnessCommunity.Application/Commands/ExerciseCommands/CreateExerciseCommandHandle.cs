using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class CreateExerciseCommandHandle(IExerciseRepository exerciseRepository, IMapper mapper,IUnitOfWork unitOfWork)
        : IRequestHandler<CreateExerciseCommand, CreateExerciseRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateExerciseRequest> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<Exercise>(request.CreateExerciseRequest);
            await _exerciseRepository.CreateAsync(exercise);
            await _unitOfWork.SaveChangesAsync();
            return request.CreateExerciseRequest;
        }
    }
}
 