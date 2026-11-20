using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TichuCounter;

public class StartupMigration
{
    public StartupMigration(IConfiguration configuration, IWebHostEnvironment environment)
    {
    }

    public void ConfigureServices(IServiceCollection services) { }
}
