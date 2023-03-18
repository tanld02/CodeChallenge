using CodeChallenge.DAL;
using CodeChallenge.DAL.Interfaces;
using CodeChallenge.Models.DTO;

namespace CodeChallenge.UnitsOfWork.DBWorkers.Movie
{
    public class GetMoviesAll_DBUOW
    {
        private readonly ILogger<GetMoviesAll_DBUOW> _logger;
        private readonly IServiceProvider _serviceProvider;

        public GetMoviesAll_DBUOW(
            ILogger<GetMoviesAll_DBUOW> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Movie_DTO>> ExecuteAsync()
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            try
            {
                // Create scope
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<IDbContext>();
                IMovieRepository movieRepository = new MovieRepository(context);

                return await movieRepository.GetMoviesAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
