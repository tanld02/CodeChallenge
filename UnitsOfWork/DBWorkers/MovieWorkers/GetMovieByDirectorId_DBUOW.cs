using CodeChallenge.DAL;
using CodeChallenge.DAL.Interfaces;
using CodeChallenge.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.UnitsOfWork.DBWorkers.Movie
{
    public class GetMovieByDirectorId_DBUOW
    {
        private readonly ILogger<GetMovieByDirectorId_DBUOW> _logger;
        private readonly IServiceProvider _serviceProvider;

        public GetMovieByDirectorId_DBUOW(
            ILogger<GetMovieByDirectorId_DBUOW> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Movie_DTO>> ExecuteAsync(Guid directorId)
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            try
            {
                // Create scope
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<IDbContext>();
                IMovieRepository movieRepository = new MovieRepository(context);

                return await movieRepository.GetMoviesByDirectorId(directorId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
