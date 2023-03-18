using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers
{
    public class GetMovieById_UOW
    {
        private readonly ILogger<GetMovieById_UOW> _logger;
        private readonly GetMovieById_DBUOW _getMovieById;

        public GetMovieById_UOW(
            ILogger<GetMovieById_UOW> logger,
            GetMovieById_DBUOW getMovieById)
        {
            _logger = logger;
            _getMovieById = getMovieById;
        }

        public async Task<Movie_DTO> ExecuteAsync(Guid movieId)
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            return await _getMovieById.ExecuteAsync(movieId);
        }
    }
}
