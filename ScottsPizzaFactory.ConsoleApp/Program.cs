using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScottsPizzaFactory.DataAccess;
using ScottsPizzaFactory.DataAccess.Factory;
using Serilog;

namespace ScottsPizzaFactory.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Pizza Factory Starting...");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IPizzaFactory, PizzaFactory>();
                    services.AddTransient<ITimer, Timer>();
                })
                .UseSerilog()
                .Build();

            var service = ActivatorUtilities.CreateInstance<PizzaFactory>(host.Services);
            service.RunPizzaFactory();

            Log.Logger.Information("Pizza Factory Terminating...");
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
