using Microsoft.Extensions.DependencyInjection;
using ScottsPizzaFactory.DataAccess.Factory;
using ScottsPizzaFactory.DataAccess.Services;


namespace ScottsPizzaFactory.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupDependencyInjection();

            var pizzaFactoryRunner = new PizzaFactory(serviceProvider);
            pizzaFactoryRunner.RunPizzaFactory();
            pizzaFactoryRunner.CreateRandomPizza();
        }

        static ServiceProvider SetupDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }

        //private static void ConfigureServices(IServiceCollection serviceCollection)
        //{
        //    // Build configuration
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
        //        .AddJsonFile("appsettings.json", false)
        //        .Build();

        //    // Add access to generic IConfigurationRoot
        //    serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
        //}
    }
}
