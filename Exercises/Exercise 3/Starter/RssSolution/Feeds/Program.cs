using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Feeds;

// TODO 1: Make a call to nu.nl/rss and process the results. Display the following data on screen
// - title
// - description
// - category
internal class Program
{
    public static void Main()
    {
        Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<ConsoleApp>();
            })
            .Build()
            .Run();
    }
}

