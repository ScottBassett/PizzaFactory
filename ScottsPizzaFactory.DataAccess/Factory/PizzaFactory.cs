using System;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ScottsPizzaFactory.DataAccess.Models;


namespace ScottsPizzaFactory.DataAccess.Factory
{
    public class PizzaFactory : IPizzaFactory
    {
        private readonly ILogger<PizzaFactory> _log;
        private readonly IConfiguration _config;

        public PizzaFactory(ILogger<PizzaFactory> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void RunPizzaFactory()
        {
            var pizzaCount = _config.GetValue<int>("pizzaCount");
            var cookingInterval = _config.GetValue<int>("cookingInterval");
            var sw = new StreamWriter(_config.GetValue<string>("textFile"));

            _log.LogInformation($"Welcome to pizza factory, {pizzaCount} pizzas coming up!");

            for (var i = 1; i < pizzaCount + 1; i++)
            {
                var pizza = CreateRandomPizza();
                _log.LogInformation($"Your {pizza.GetDescription()} pizza will be ready in {pizza.TotalCookingTime} seconds");
                //Thread.Sleep((int)pizza.PizzaCookingTimeInMilliseconds);
                Thread.Sleep(cookingInterval);
                //_log.LogInformation($"{pizza.PizzaName} is ready!");
                sw.WriteLine($"{i}. {pizza.GetDescription()}");
            }

            sw.Close();
            _log.LogInformation("Thank you for your order.");
        }

        private PizzaTopping CreateRandomTopping()
        {
            var toppingsFromConfig = _config.GetSection("pizzaToppings");

            PizzaTopping[] toppings =
            {
                new PizzaTopping(toppingsFromConfig.GetSection("hamAndMushroom").GetValue<string>("toppingName")),
                new PizzaTopping(toppingsFromConfig.GetSection("pepperoni").GetValue<string>("toppingName")),
                new PizzaTopping(toppingsFromConfig.GetSection("vegetable").GetValue<string>("toppingName"))
            };

            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];
        }

        private PizzaBase CreateRandomBase()
        {
            var basesFromConfig = _config.GetSection("pizzaBases");

            PizzaBase[] bases =
            {
                new PizzaBase(basesFromConfig.GetSection("thinAndCrispy").GetValue<string>("baseName"),basesFromConfig.GetSection("thinAndCrispy").GetValue<double>("multiplier")),
                new PizzaBase(basesFromConfig.GetSection("stuffedCrust").GetValue<string>("baseName"),basesFromConfig.GetSection("stuffedCrust").GetValue<double>("multiplier")),
                new PizzaBase(basesFromConfig.GetSection("deepPan").GetValue<string>("baseName"),basesFromConfig.GetSection("deepPan").GetValue<double>("multiplier")),
            };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }

        public Pizza CreateRandomPizza() => new Pizza(CreateRandomBase(), CreateRandomTopping());
    }
}
