using RWE.App.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using RWE.App.Core.Interfaces;
using MediatR;
using RWE.App.Core.Queries.Movies;
using RWE.App.Core.Commands.Movies;

namespace RWE.App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private IMediator _mediator;

        public MoviesController(
            ILogger<MoviesController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMoviesAll()
        {
            try
            {
                var result = await _mediator.Send(new GetMoviesAllQuery()).ConfigureAwait(false);
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

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById(Guid movieId)
        {
            try
            {
                var result = await _mediator.Send(new GetMovieByIdQuery() { Id = movieId}).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetMovieByDirector/{directorId}")]
        public async Task<IActionResult> GetMovieByDirector(Guid directorId)
        {
            try
            {
                var result = await _mediator.Send(new GetMoviesByDirectorIdQuery() { DirectorId = directorId }).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetMovieByDirectorName/{directorName}")]
        public async Task<IActionResult> GetMovieByDirectorName(string directorName)
        {
            try
            {
                var result = await _mediator.Send(new GetMoviesByDirectorNameQuery() { DirectorName = directorName }).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Movie_DTO data)
        {
            try
            {
                var result = await _mediator.Send(new UpdateMovieCommand() {Dto = data }).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie_DTO data)
        {
            try
            {
                var result = await _mediator.Send(new CreateMovieCommand() { Dto = data }).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteMovieCommand() { Id = movieId }).ConfigureAwait(false);
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