using RWE.App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RWE.App.Infrastructure.Repository;
using RWE.App.Infrastructure.UnitsOfWork;

namespace RWE.App.Infrastructure;

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
