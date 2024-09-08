using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class DeleteExerciseCommandHandle : IRequestHandler<DeleteExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExerciseCommandHandle(IExerciseRepository exerciseRepository,
            IUnitOfWork unitOfWork)
        {
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }

            await _exerciseRepository.DeleteAsync(exercise.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
