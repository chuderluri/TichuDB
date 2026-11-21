using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TichuCounter.Data;

namespace TichuCounter;

public static class CommonStartupHelpers
{
    public static void ConfigureDatabase(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        serviceCollection.AddDbContext<TichuCounterDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
