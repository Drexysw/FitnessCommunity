using AutoMapper;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Exceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class DeleteExerciseCommandHandle(
        IExerciseRepository exerciseRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : IRequestHandler<DeleteExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId);
            if (exercise == null)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }

            await exerciseRepository.DeleteAsync(exercise.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
