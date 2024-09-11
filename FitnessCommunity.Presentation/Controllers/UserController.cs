using AutoMapper;
using FitnessCommunity.Application.Commands.UserCommands;
using FitnessCommunity.Application.Dtos.UserDtos.Requests;
using FitnessCommunity.Application.Queries.UserQueries;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitnessCommunity.Presentation.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, ILogger<UserController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return RedirectToAction("Index","Home");
        }
    
    
        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id,[FromBody] UpdateUserRequest request)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("UserId is empty");
                return BadRequest();
            }
            var command = _mapper.Map<UpdateUserCommand>(request);
            command.Id = id;
            try
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(GetUser), new { id });
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpPost]
        [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("UserId is empty");
                return BadRequest();
            }
            var command = new DeleteUserCommand(id);
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (UserNotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("UserId is empty");
                return BadRequest();
            }
            var command = new GetUserByIdQuery(id);
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
    }
}
