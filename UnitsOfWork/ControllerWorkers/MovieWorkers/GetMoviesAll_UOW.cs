using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers
{
    public class GetMoviesAll_UOW
    {
        private readonly ILogger<GetMoviesAll_UOW> _logger;
        private readonly GetMoviesAll_DBUOW _getAllMovies;

        public GetMoviesAll_UOW(
            ILogger<GetMoviesAll_UOW> logger,
            GetMoviesAll_DBUOW getAllMovies)
        {
            _logger = logger;
            _getAllMovies = getAllMovies;
        }

        public async Task<IEnumerable<Movie_DTO>> ExecuteAsync()
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            return await _getAllMovies.ExecuteAsync();
        }
    }
}
