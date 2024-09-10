using AutoMapper;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class UpdateExerciseCommandHandle : IRequestHandler<UpdateExerciseCommand, Unit>
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

        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }

            var updatedExercise = _mapper.Map<Exercise>(request);
            await _exerciseRepository.UpdateAsync(updatedExercise);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
