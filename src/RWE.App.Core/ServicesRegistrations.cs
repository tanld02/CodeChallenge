using Microsoft.Extensions.DependencyInjection;
using RWE.App.Core.Interfaces;
using RWE.App.Core.Services;

namespace RWE.App.Core;

public static class ServicesRegistrations
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IMovieService, MovieService>();
    }
}
