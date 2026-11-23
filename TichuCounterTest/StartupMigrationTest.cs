using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TichuCounter;
using TichuCounter.Data;

namespace TichuCounterTest;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class StartupMigrationTest
{
    [Test]
    public void CanResolveDbContext()
    {
        // Arrange
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(
            [
                new KeyValuePair<string, string?>("ConnectionStrings:DefaultConnection", "server=localhost"),
            ]
        );

        var configuration = configurationBuilder.Build();

        var environment = new Mock<IWebHostEnvironment>();
        environment.SetupGet(e => e.EnvironmentName).Returns("DatabaseMigration");

        var startup = new StartupMigration(configuration, environment.Object);

        var collection = new ServiceCollection();

        // collection.AddSingleton<IConfiguration>(configuration);
        // collection.AddSingleton(Mock.Of<IHttpContextAccessor>());

        // Act
        startup.ConfigureServices(collection);
        var serviceProvider = collection.BuildServiceProvider();
        var resolved = serviceProvider.GetRequiredService<TichuCounterDbContext>();

        // Assert
        Assert.That(resolved, Is.Not.Null);
        Assert.That(resolved, Is.InstanceOf<TichuCounterDbContext>());
    }
}
