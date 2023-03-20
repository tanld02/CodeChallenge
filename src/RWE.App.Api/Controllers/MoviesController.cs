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
            var result = await _unitOfWork.MovieRepository.GetAllAsync().ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById(Guid movieId)
        {
            var result = await _unitOfWork.MovieRepository.GetByIdAsync(movieId).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("GetMovieByDirector/{directorId}")]
        public async Task<IActionResult> GetMovieByDirector(Guid directorId)
        {
            var result = await _unitOfWork.MovieRepository.GetMoviesByDirectorId(directorId).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetMovieByDirectorName/{directorName}")]
        public async Task<IActionResult> GetMovieByDirectorName(string directorName)
        {
            var result = await _unitOfWork.MovieRepository.GetMoviesByDirectorName(directorName).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Movie_DTO data)
        {
            var result = await _unitOfWork.MovieRepository.UpdateMovie(data).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            var result = await _unitOfWork.MovieRepository.DeleteMovie(movieId).ConfigureAwait(false);
            if(result == Guid.Empty)
            {
                return NotFound();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}