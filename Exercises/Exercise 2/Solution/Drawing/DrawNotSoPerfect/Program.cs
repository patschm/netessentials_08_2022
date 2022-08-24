// TODO 1: Include the necessary packages for dependency Injection
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shapes;


namespace DrawNotSoPerfect;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // TODO 2: Modify this code to wire up the Dependency Injection infrastructure.
        // TODO 3: Register LocalFileStorage class in the Dependency Injector

        // TODO 5: Configure logging. Clear all log providers and add the Debug Provider
        // (writes output to "Output" window in Visual Studio).
        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();
        Application.Run(host.Services.GetRequiredService<DrawMain>());
    }
    
    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            //.ConfigureAppConfiguration((ctx, cf) => {
            //    cf.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json");
            //})
            .ConfigureLogging(bld =>
            {
                bld.ClearProviders();
                bld.AddDebug();
            })
            .ConfigureServices((ctx, services) => {
                services.AddTransient<DrawMain>();
                services.AddSingleton<IStorage, LocalFileStorage>();
            });
    }
}