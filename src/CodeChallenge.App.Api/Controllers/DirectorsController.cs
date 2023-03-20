using MediatR;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.App.Core.Commands.Directors;
using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Queries.Directors;

namespace CodeChallenge.App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorsController :  ControllerBase
    {
        private readonly ILogger<DirectorsController> _logger;
        private IMediator _mediator;

        public DirectorsController(
            ILogger<DirectorsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetDirectorsAll()
        {
            try
            {
                var result = await _mediator.Send(new GetDirectorsAllQuery()).ConfigureAwait(false);
                if(result == null)
                {
                    return NoContent();
                }    
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{directorId}")]
        public async Task<IActionResult> GetDirectorById(Guid directorId)
        {
            try
            {
                if (directorId == Guid.Empty)
                {
                    return BadRequest();
                }
                var result = await _mediator.Send(new GetDirectorByIdQuery() { Id = directorId}).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector(Director_DTO director)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _mediator.Send(new CreateDirectorCommand() { Dto = director }).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDirector(Director_DTO director)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _mediator.Send(new UpdateDirectorCommand() { Dto = director }).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDirector(Guid directorId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDirectorCommand() { Id = directorId }).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
