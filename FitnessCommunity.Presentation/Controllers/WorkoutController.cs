using AutoMapper;
using FitnessCommunity.Application.Commands.WorkoutCommands;
using FitnessCommunity.Application.Commands.WorkoutExerciseCommands;
using FitnessCommunity.Application.Dtos.WorkoutDtos.Requests;
using FitnessCommunity.Application.Queries.WorkoutQueries;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using FitnessCommunity.Domain.Exceptions.WorkoutExceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitnessCommunity.Presentation.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkoutController> _logger;
        public WorkoutController(IMediator mediator, IMapper mapper, ILogger<WorkoutController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [Route("api/workouts")]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var getAllWorkoutsQuery = new GetAllWorkoutQuery();
            var result = await _mediator.Send(getAllWorkoutsQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("api/workouts/{id}")]
        public async Task<IActionResult> GetWorkoutById(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }
            var getWorkoutByIdQuery = new GetWorkoutByIdQuery(id);
            try
            {
                var result = await _mediator.Send(getWorkoutByIdQuery);
                return Ok(result);
            }
            catch (WorkoutNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
        [Authorize]
        [HttpPost]
        [Route("api/workouts")]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutRequest request)
        {
            var createWorkoutCommand = _mapper.Map<CreateWorkoutCommand>(request);
            var result = await _mediator.Send(createWorkoutCommand);
            return RedirectToAction(nameof(GetWorkoutById), new { id = result });
        }
        [Authorize]
        [HttpPut]
        [Route("api/workouts/{id}")]
        public async Task<IActionResult> UpdateWorkout(Guid id, [FromBody] UpdateWorkoutRequest request)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }
            var updateWorkoutCommand = _mapper.Map<UpdateWorkoutCommand>(request);
            updateWorkoutCommand.Id = id;
            try
            {
                await _mediator.Send(updateWorkoutCommand);
                return RedirectToAction(nameof(GetWorkoutById), new {id});
            }
            catch (WorkoutNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("api/workouts/{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }
            var deleteWorkoutCommand = new DeleteWorkoutCommand(id);
            try
            { 
                await _mediator.Send(deleteWorkoutCommand);
                return RedirectToAction(nameof(GetAllWorkouts));
            }
            catch (WorkoutNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/workouts/{workoutId}/exercises/{exerciseId}")]
        public async Task<IActionResult> AddExerciseToWorkout(Guid workoutId,Guid exerciseId)
        {
            if (workoutId == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }

            if (exerciseId == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }
            var addExerciseToWorkoutCommand = new AddExerciseToWorkoutCommand(workoutId, exerciseId);
            try
            {
                var result = await _mediator.Send(addExerciseToWorkoutCommand);
                return CreatedAtAction(nameof(GetWorkoutById), new { id = workoutId }, result);
            }
            catch (ExerciseNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (WorkoutNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }

        }
        [Authorize]
        [HttpDelete]
        [Route("api/workouts/{workoutId}/exercises/{exerciseId}")]
        public async Task<IActionResult> RemoveExerciseFromWorkout(Guid workoutId, Guid exerciseId)
        {
            if (workoutId == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }

            if (exerciseId == Guid.Empty)
            {
                _logger.LogError("WorkoutId is empty");
                return BadRequest();
            }

            var removeExerciseFromWorkoutCommand = new RemoveExerciseFromWorkoutCommand(workoutId, exerciseId);
            try
            {
                var result = await _mediator.Send(removeExerciseFromWorkoutCommand);
                return CreatedAtAction(nameof(GetWorkoutById), new { id = workoutId }, result);
            }
            catch (ExerciseNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (WorkoutNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
    }
}
