using CodeChallenge.DAL;
using CodeChallenge.DAL.Interfaces;
using CodeChallenge.Models.DTO;

namespace CodeChallenge.UnitsOfWork.DBWorkers.Movie
{
    public class GetMovieById_DBUOW
    {
        private readonly ILogger<GetMovieById_DBUOW> _logger;
        private readonly IServiceProvider _serviceProvider;

        public GetMovieById_DBUOW(
            ILogger<GetMovieById_DBUOW> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<Movie_DTO> ExecuteAsync(Guid movieId)
        {
            var source = this.GetType().Name;
            _logger.LogInformation($"Starting {source}");

            try
            {
                // Create scope
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<IDbContext>();
                IMovieRepository movieRepository = new MovieRepository(context);

                return await movieRepository.GetMovieById(movieId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
