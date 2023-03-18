using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly GetMoviesAll_UOW _getAllMovies;
        private readonly GetMovieById_UOW _getMovieById;
        private readonly GetMovieByDirectorId_UOW _getMovieByDirectorId;
        private readonly GetMovieByDirectorName_UOW _getMovieByDirectorName;
        private readonly UpdateMovie_UOW _updateMovie;

        public MoviesController(
            ILogger<MoviesController> logger,
            GetMoviesAll_UOW getAllMovies,
            GetMovieById_UOW getMovieById,
            GetMovieByDirectorId_UOW getMovieByDirectorId,
            GetMovieByDirectorName_UOW getMovieByDirectorName,
            UpdateMovie_UOW updateMovie)
        {
            _logger = logger;
            _getAllMovies = getAllMovies;
            _getMovieById = getMovieById;
            _getMovieByDirectorId = getMovieByDirectorId;
            _getMovieByDirectorName = getMovieByDirectorName;
            _updateMovie = updateMovie;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMoviesAll()
        {
            var result = await _getAllMovies.ExecuteAsync();

            return Ok(result);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieById(Guid movieId)
        {
            var result = await _getMovieById.ExecuteAsync(movieId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("GetMovieByDirector/{directorId}")]
        public async Task<IActionResult> GetMovieByDirector(Guid directorId)
        {
            var result = await _getMovieByDirectorId.ExecuteAsync(directorId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetMovieByDirectorName/{directorName}")]
        public async Task<IActionResult> GetMovieByDirectorName(string directorName)
        {
            var result = await _getMovieByDirectorName.ExecuteAsync(directorName);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}