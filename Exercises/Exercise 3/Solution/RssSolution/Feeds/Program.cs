using Feeds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        ViaDI();
        //LeanAndMean();

        Console.ReadLine();
    }

    private static async Task LeanAndMean()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://nu.nl/");

        var result = await client.GetAsync("rss");
        if (result.IsSuccessStatusCode)
        {
            using(var str = await result.Content.ReadAsStreamAsync())
            foreach(var item in Process(str))
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
        }
    }
 
    static IEnumerable<Item> Process(Stream stream)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        var reader = XmlReader.Create(stream);

        while (reader.ReadToFollowing("item"))
        {
            var item = serializer.Deserialize(reader.ReadSubtree()) as Item;
            if (item != null) yield return item;
        }
    }  
    static void ViaDI()
    {
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
    }
}

        
