using Microsoft.Extensions.Hosting;

namespace Feeds
{
    public class ConsoleApp : IHostedService
    {
        private IFeedReader _feedReader;

        public ConsoleApp(IFeedReader feedReader)
        {
            _feedReader = feedReader;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var item in _feedReader.Read())
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.Category);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Title);
                Console.ResetColor();
                Console.WriteLine(item.Description);
                Console.WriteLine();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
