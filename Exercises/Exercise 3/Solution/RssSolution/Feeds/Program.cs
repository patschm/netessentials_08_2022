using Feeds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient("nu", client =>
        {
            client.BaseAddress = new Uri("https://nu.nl/");
        }).SetHandlerLifetime(TimeSpan.FromMinutes(10));
        services.AddTransient<IProcessStreamStrategy, XmlSerializerStrategy>();
        //services.AddTransient<IProcessStreamStrategy, RegexpStrategy>();
        //services.AddTransient<IProcessStreamStrategy, LinqToXmlStrategy>();
        services.AddTransient<IFeedReader, FeedReader>();
        services.AddHostedService<ConsoleApp>();
    })
    .Build()
    .Run();
        
