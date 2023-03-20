using Microsoft.Extensions.DependencyInjection;
using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Services;

namespace CodeChallenge.App.Core;

public static class ServicesRegistrations
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IMovieService, MovieService>();
    }
}
