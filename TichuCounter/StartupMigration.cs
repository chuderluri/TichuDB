using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TichuCounter;

public class StartupMigration
{
    private readonly IConfiguration _configuration;

    public StartupMigration(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        CommonStartupHelpers.ConfigureDatabase(services, _configuration);
    }
}
