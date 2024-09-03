using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommandHandle(
        IExerciseRepository exerciseRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : IRequestHandler<UpdateExerciseCommand, UpdateExerciseRequest>
    {
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<UpdateExerciseRequest> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.UpdateExerciseRequest.Id);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }

            var updatedExercise = _mapper.Map(request.UpdateExerciseRequest, exercise);
            await exerciseRepository.UpdateAsync(updatedExercise);
            await _unitOfWork.SaveChangesAsync();
            return request.UpdateExerciseRequest;
        }
    }
}
