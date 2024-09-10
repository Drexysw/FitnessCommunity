using AutoMapper;
using FitnessCommunity.Application.Commands.ExerciseCommands;
using FitnessCommunity.Application.Dtos.ExerciseDtos.Requests;
using FitnessCommunity.Application.Queries.ExerciseQueries;
using FitnessCommunity.Domain.Exceptions.ExcerciseExceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitnessCommunity.Presentation.Controllers
{
    public class ExerciseController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(IMediator mediator, IMapper mapper, ILogger<ExerciseController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("api/exercises")]
        public async Task<IActionResult> GetExercises()
        {
            var query = new GetAllExerciseQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("api/exercises/{id}")]
        public async Task<IActionResult> GetExerciseById(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("ExerciseId is empty");
                return BadRequest();
            }
            var query = new GetByIdExerciseQuery(id);
            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (ExerciseNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("api/exercises")]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseRequest request)
        {
            var command = _mapper.Map<CreateExerciseCommand>(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetExerciseById), new { id = request.Id }, result);
        }

        [Authorize]
        [HttpPut("api/exercises/{id}")]
        public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] UpdateExerciseRequest request)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("ExerciseId is empty");
                return BadRequest();
            }
            var command = _mapper.Map<UpdateExerciseCommand>(request);
            command.Id = id;
            try
            {
                var result = await _mediator.Send(command);
                return RedirectToAction(nameof(GetExerciseById), new { id });
            }
            catch (ExerciseNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpDelete("api/exercises/{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("ExerciseId is empty");
                return BadRequest();
            }
            var command = new DeleteExerciseCommand(id);
            try
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(GetExercises));
            }
            catch (ExerciseNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
    }
}
