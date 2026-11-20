using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using TichuCounter.Data;

namespace TichuCounter;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseNLog();

            if (builder.Environment.IsEnvironment("DatabaseMigration"))
            {
                await DatabaseMigration(builder, args.Contains("--verify-only"));
                return;
            }

            await ExecuteApplication(builder);
        }
        catch (Exception e)
        {
            logger.Fatal(e, "Application stopped due to exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }

    private static async Task ExecuteApplication(WebApplicationBuilder builder)
    {
        var startup = new Startup(builder.Configuration, builder.Environment);

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        startup.Configure(app, app.Environment);

        await app.RunAsync();
    }

    private static async Task DatabaseMigration(WebApplicationBuilder builder, bool verifyOnly)
    {
        var startup = new StartupMigration(builder.Configuration, builder.Environment);
        startup.ConfigureServices(builder.Services);

        var webApp = builder.Build();
        await using var scope = webApp.Services.CreateAsyncScope();
        var dbContext = webApp.Services.GetRequiredService<TichuCounterDbContext>();

        if (dbContext.Database.HasPendingModelChanges())
        {
            throw new ApplicationException("Database has pending model changes!");
        }

        if ((await dbContext.Database.GetAppliedMigrationsAsync()).Except(dbContext.Database.GetMigrations()).Any())
        {
            throw new ApplicationException("Database has applied migrations that are not present in assembly!");
        }

        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            if (verifyOnly)
            {
                throw new ApplicationException("Database has pending migration!");
            }

            await dbContext.Database.MigrateAsync();
        }
    }
}
