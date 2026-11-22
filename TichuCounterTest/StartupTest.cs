using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TichuCounter;
using TichuCounter.Data;

namespace TichuCounterTest;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class StartupTest
{
   private static ServiceProvider _services = null!;

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(
            [
                new KeyValuePair<string, string?>("ServiceBus:Disabled", "true"),
                new KeyValuePair<string, string?>("ConnectionStrings:DefaultConnection", "server=localhost"),
            ]
        );

        var configuration = configurationBuilder.Build();

        var environment = new Mock<IWebHostEnvironment>();
        environment.SetupGet(e => e.EnvironmentName).Returns("Development");

        var startup = new Startup(configuration, environment.Object);

        var collection = new ServiceCollection();

        collection.AddSingleton<IConfiguration>(configuration);

        // ACT
        startup.ConfigureServices(collection);

        _services = collection.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public static async Task OneTimeTearDown()
    {
        await _services.DisposeAsync();
    }

    [TestCaseSource(nameof(GetDynamicResolvedTypes))]
    public async Task CanResolve(Type type)
    {
        await using var scope = _services.CreateAsyncScope();
        var resolved = scope.ServiceProvider.GetRequiredService(type);
        Assert.That(resolved, Is.Not.Null.And.InstanceOf(type));
    }

    private static IEnumerable<Type> GetDynamicResolvedTypes()
    {
        yield return typeof(TichuCounterDbContext);

        // yield return typeof(HealthCheckService);

        // var typesInAssembly = Assembly.GetAssembly(typeof(Startup))?.GetTypes().Where(t => t is { IsClass: true, IsAbstract: false }).ToArray() ?? [];

        // foreach (var consumer in typesInAssembly.Where(t => t.GetInterfaces().Contains(typeof(IConsumer))))
        // {
            // yield return consumer;
        // }

        // foreach (var job in typesInAssembly.Where(t => t.GetInterfaces().Contains(typeof(IJob))))
        // {
            // yield return job;
        // }
    }
}
