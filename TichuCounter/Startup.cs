using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TichuCounter.Util;

namespace TichuCounter;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Data
        CommonStartupHelpers.ConfigureDatabase(services, _configuration);

        // Util
        services.AddScoped<IAuditNameProvider, AuditNameProvider>();
        services.AddSingleton(TimeProvider.System);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }
}
