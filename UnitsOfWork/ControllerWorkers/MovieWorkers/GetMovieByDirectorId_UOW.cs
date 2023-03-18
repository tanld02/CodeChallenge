using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers
{
    public class GetMovieByDirectorId_UOW
    {
        private readonly ILogger<GetMovieByDirectorId_UOW> _logger;
        private readonly GetMovieByDirectorId_DBUOW _getMovieByDirectorId;

        public GetMovieByDirectorId_UOW(
            ILogger<GetMovieByDirectorId_UOW> logger,
            GetMovieByDirectorId_DBUOW getMovieByDirectorId)
        {
            _logger = logger;
            _getMovieByDirectorId = getMovieByDirectorId;
        }

        public async Task<IEnumerable<Movie_DTO>> ExecuteAsync(Guid directorId)
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            return await _getMovieByDirectorId.ExecuteAsync(directorId);
        }
    }
}
