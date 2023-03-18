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

        public MoviesController(
            ILogger<MoviesController> logger,
            GetMoviesAll_UOW getAllMovies,
            GetMovieById_UOW getMovieById)
        {
            _logger = logger;
            _getAllMovies = getAllMovies;
            _getMovieById = getMovieById;
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
    }
}