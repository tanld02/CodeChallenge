using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers
{
    public class GetMovieByDirectorName_UOW
    {
        private readonly ILogger<GetMovieByDirectorName_UOW> _logger;
        private readonly GetMovieByDirectorName_DBUOW _getMovieByDirectorName;

        public GetMovieByDirectorName_UOW(
            ILogger<GetMovieByDirectorName_UOW> logger,
            GetMovieByDirectorName_DBUOW getMovieByDirectorName)
        {
            _logger = logger;
            _getMovieByDirectorName = getMovieByDirectorName;
        }

        public async Task<IEnumerable<Movie_DTO>> ExecuteAsync(string directorName)
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            return await _getMovieByDirectorName.ExecuteAsync(directorName);
        }
    }
}
