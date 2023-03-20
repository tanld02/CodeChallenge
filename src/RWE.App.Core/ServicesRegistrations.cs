using Microsoft.Extensions.DependencyInjection;

namespace RWE.App.Core;

public static class ServicesRegistrations
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        //// Controller UOWs
        //services.AddTransient<GetMoviesAll_UOW>();
        //services.AddTransient<GetMovieById_UOW>();
        //services.AddTransient<GetMovieByDirectorId_UOW>();
        //services.AddTransient<GetMovieByDirectorName_UOW>();

        //// DB UOWs
        //services.AddTransient<GetMoviesAll_DBUOW>();
        //services.AddTransient<GetMovieById_DBUOW>();
        //services.AddTransient<GetMovieByDirectorId_DBUOW>();
        //services.AddTransient<GetMovieByDirectorName_DBUOW>();
    }
}
