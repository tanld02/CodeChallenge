using CodeChallenge.App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodeChallenge.App.Infrastructure.Repository;
using CodeChallenge.App.Infrastructure.UnitsOfWork;

namespace CodeChallenge.App.Infrastructure;

public static class ServicesRegistrations
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IDbContext, CodeChallengeContext>(options => options.UseSqlServer(configuration["LocalDBCS"]));
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
