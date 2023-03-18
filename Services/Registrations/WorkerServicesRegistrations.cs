using CodeChallenge.UnitsOfWork.ControllerWorkers.MovieWorkers;
using CodeChallenge.UnitsOfWork.DBWorkers.Movie;

namespace CodeChallenge.Services.Registrations
{
    public static class WorkerServicesRegistrations
    {
        public static void RegisterWorkerServices(this IServiceCollection services)
        {
            // Controller UOWs
            services.AddTransient<GetMoviesAll_UOW>();
            services.AddTransient<GetMovieById_UOW>();

            // DB UOWs
            services.AddTransient<GetMoviesAll_DBUOW>();
            services.AddTransient<GetMovieById_DBUOW>();
        }
    }
}
