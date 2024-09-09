using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommandHandle : IRequestHandler<UpdateExerciseCommand, UpdateExerciseRequest>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExerciseCommandHandle(IExerciseRepository exerciseRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateExerciseRequest> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }

            var updatedExercise = _mapper.Map(request.UpdateExerciseRequest, exercise);
            await _exerciseRepository.UpdateAsync(updatedExercise);
            await _unitOfWork.SaveChangesAsync();
            return request.UpdateExerciseRequest;
        }
    }
}
