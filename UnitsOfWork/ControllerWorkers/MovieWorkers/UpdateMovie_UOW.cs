using CodeChallenge.Models.DTO;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers
{
    public class UpdateMovie_UOW
    {
        private readonly ILogger<UpdateMovie_UOW> _logger;
        private readonly GetMovieByDirectorId_DBUOW _getMovieByDirectorId;

        public UpdateMovie_UOW(
            ILogger<UpdateMovie_UOW> logger,
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
