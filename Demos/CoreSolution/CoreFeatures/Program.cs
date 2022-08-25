using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

namespace CoreFeatures;

// Used Nuget packages:
// Microsoft.Extensions.Configuration, Version="6.0.1"
// Microsoft.Extensions.Configuration.Ini, Version="6.0.0"
// Microsoft.Extensions.Configuration.Json, Version="6.0.0" 
// Microsoft.Extensions.Configuration.Xml, Version="6.0.0"
// Microsoft.Extensions.DependencyInjection, Version="6.0.0"
// Microsoft.Extensions.Hosting, Version="6.0.1"
// Microsoft.Extensions.Logging, Version="6.0.0"
// Microsoft.Extensions.Logging.Console, Version="6.0.0"
internal class Program
{
    static void Main(string[] args)
    {
        //DependencyInjection();
        //Configuration();
        //Logging();
        AllTogetherNow();

        Console.ReadLine();
    }
    private static void DependencyInjection()
    {
        var factory = new DefaultServiceProviderFactory();
        var services = new ServiceCollection();
        var builder = factory.CreateBuilder(services);
        builder.AddHostedService<ConsoleHost>();
        builder.AddTransient<ICounter, Counter>();
        // builder.AddScoped<ICounter, Counter>();
        //builder.AddSingleton<ICounter, Counter>();
        builder.AddTransient<Test>();
        var provider = builder.BuildServiceProvider();

        var test = provider.GetRequiredService<Test>();
        test.Run();

        
        Console.WriteLine("==== Run 1 ====");
        //using (var scope = provider.CreateScope())
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        var _counter = scope.ServiceProvider.GetRequiredService<ICounter>();
        //        _counter.Increment();
        //        _counter.Show();
        //    }
        //}
        var host = provider.GetRequiredService<IHostedService>();
        host.StartAsync(CancellationToken.None).Wait();
        Console.WriteLine("==== Run 2 ====");
        //using (var scope = provider.CreateScope())
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        var _counter = scope.ServiceProvider.GetRequiredService<ICounter>();
        //        _counter.Increment();
        //        _counter.Show();
        //    }
        //}
        host = provider.GetRequiredService<IHostedService>();
        host.StartAsync(CancellationToken.None).Wait();
    }
    private static void Configuration()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", false, true);
        builder.AddIniFile("startup.ini");
        builder.AddXmlFile("config.xml");
        IConfigurationRoot config = builder.Build();

        var val = config.GetValue<string>("mySettings33:Key1");
        Console.WriteLine(val);
        var jsonSettings = config.GetSection("mySettings33").Get<MySettings>();
        Console.WriteLine($"Key 1={jsonSettings.Key1}, Key 2={jsonSettings.Key2}");
        var xmlConfig = config.GetSection("myConfig").Get<MySettings>();
        Console.WriteLine($"Key 1={xmlConfig.Key1}, Key 2={xmlConfig.Key2}");
        var iniStartup = config.GetSection("myStartup").Get<MySettings>();
        Console.WriteLine($"Key 1={iniStartup.Key1}, Key 2={iniStartup.Key2}");
    }
    private static void Logging()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", false, true);
        var config = builder.Build();

        var factory = LoggerFactory.Create(bld => {
            bld.AddConfiguration(config.GetSection("Logging"));
            bld.ClearProviders();
            bld.AddConsole();
            bld.AddDebug();
            bld.AddEventLog();
        });
        ILogger<LogVictim> logger = factory.CreateLogger<LogVictim>();
        var obj = new LogVictim(logger);
        obj.DoSomeStuff();       
    }
    private static void AllTogetherNow()
    {
        // Host puts all the goodies in one. 
        // Use Host for all non-web applications.
        // WebHost (net 5.0 or lower) is the one needed for aspnet webapi/mvc
        // WebApplication (net 6 or higher) is the one needed for aspnet webapi/mvc

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(conf =>
            {
                //conf.AddJsonFile("appsettings.json"); // Not needed. Is Default
            })
            .ConfigureServices(scol =>
            {
                scol.AddHostedService<ConsoleHost>();
                scol.AddScoped<ICounter, Counter>();
                scol.AddTransient<LogVictim>();
            })
            .ConfigureLogging(log =>
            {
                //log.AddConsole(); // Not needed. Is default
            })
            .Build();

        var logvictim = host.Services.GetRequiredService<LogVictim>();
        logvictim.DoSomeStuff();

        host.Start();


    } 
  } 