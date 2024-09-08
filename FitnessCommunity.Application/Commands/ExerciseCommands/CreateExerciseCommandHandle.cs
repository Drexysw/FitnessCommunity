﻿using AutoMapper;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Commands.ExerciseCommands
{
    public class CreateExerciseCommandHandle : IRequestHandler<CreateExerciseCommand, CreateExerciseRequest>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExerciseCommandHandle(IExerciseRepository exerciseRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateExerciseRequest> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<Exercise>(request.CreateExerciseRequest);
            await _exerciseRepository.CreateAsync(exercise);
            await _unitOfWork.SaveChangesAsync();
            return request.CreateExerciseRequest;
        }
    }
}
 