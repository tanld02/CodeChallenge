using RWE.App.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using RWE.App.Core.Interfaces;

namespace RWE.App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(
            ILogger<MoviesController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMoviesAll()
        {
            try
            {
                var result = await _unitOfWork.MovieRepository.GetMoviesAll().ConfigureAwait(false);
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
                var result = await _unitOfWork.MovieRepository.GetMovieById(movieId).ConfigureAwait(false);

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
                var result = await _unitOfWork.MovieRepository.GetMoviesByDirectorId(directorId).ConfigureAwait(false);

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
                var result = await _unitOfWork.MovieRepository.GetMoviesByDirectorName(directorName).ConfigureAwait(false);

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
                var result = await _unitOfWork.MovieRepository.UpdateMovie(data).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
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
                var result = await _unitOfWork.MovieRepository.DeleteMovie(movieId).ConfigureAwait(false);
                if (result == Guid.Empty)
                {
                    return NotFound();
                }
                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
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