using Microsoft.Extensions.Hosting;

namespace Feeds;

public class ConsoleApp : IHostedService
{
    public ConsoleApp()
    {
        
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
