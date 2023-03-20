using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Api.Models;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.App.Core;
using CodeChallenge.App.Infrastructure;
using MediatR;
using System.Reflection;

namespace CodeChallenge.App.Api;

public class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment env)
    {
        Configuration = configuration;
        Env = env;
    }

    public IConfiguration Configuration { get; }
    public IHostEnvironment Env { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration);

        //services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        // Add Dependency Core Layer
        services.AddCoreServices();
        // Add Dependency Infrastructure Layer
        services.AddInfrastructureServices(Configuration);
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
