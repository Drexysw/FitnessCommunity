using AutoMapper;
using FitnessCommunity.Application.Commands.BadgeCommands;
using FitnessCommunity.Application.Dtos.BadgeDtos.Requests;
using FitnessCommunity.Application.Queries.BadgeQueries;
using FitnessCommunity.Domain.Exceptions.BadgeExceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitnessCommunity.Presentation.Controllers
{
    public class BadgeController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;   
        private readonly ILogger<BadgeController> _logger;
        public BadgeController(IMediator mediator, IMapper mapper, ILogger<BadgeController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [Route("api/badges")]
        public async Task<IActionResult> GetAllBadges()
        {
            var getAllBadgesQuery = new GetAllBadgesQuery();
            var result = await _mediator.Send(getAllBadgesQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("api/badges/{id}")]
        public async Task<IActionResult> GetBadgeById(Guid id)
        {
            var getBadgeByIdQuery = new GetBadgeByIdQuery(id);
            try
            {
                var result = await _mediator.Send(getBadgeByIdQuery);
                return Ok(result);
            }
            catch (BadgeNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
        [Authorize]
        [HttpPost]
        [Route("api/badges")]
        public async Task<IActionResult> CreateBadge([FromBody] CreateBadgeRequest request)
        {
            var createBadgeCommand = _mapper.Map<CreateBadgeCommand>(request);
            var result = await _mediator.Send(createBadgeCommand);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        [Route("api/badges/{id}")]
        public async Task<IActionResult> UpdateBadge(Guid id, [FromBody] UpdateBadgeRequest request)
        {
            var updateBadgeCommand = _mapper.Map<UpdateBadgeCommand>(request);
            updateBadgeCommand.Id = id;
            try
            {
                var result = await _mediator.Send(updateBadgeCommand);
                return RedirectToAction(nameof(GetBadgeById),new {id});
            }
            catch (BadgeNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("api/badges/{id}")]
        public async Task<IActionResult> DeleteBadge(Guid id)
        {
            var deleteBadgeCommand = new DeleteBadgeCommand(id);
            try
            {
                var result = await _mediator.Send(deleteBadgeCommand);
                return RedirectToAction(nameof(GetAllBadges));
            }
            catch (BadgeNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
    }
}
