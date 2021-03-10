using System;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ScottsPizzaFactory.DataAccess.Models.Bases;
using ScottsPizzaFactory.DataAccess.Models.Pizza;
using ScottsPizzaFactory.DataAccess.Models.Toppings;


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
            var amountOfPizzas = _config.GetValue<int>("pizzaCount");
            var sw = new StreamWriter(_config.GetValue<string>("textFile"));

            _log.LogInformation($"Welcome to pizza factory, {amountOfPizzas} pizzas coming up!");

            for (var i = 1; i < amountOfPizzas+1; i++)
            {
                var pizza = CreateRandomPizza();
                _log.LogInformation($"Your {pizza.PizzaName} pizza will be ready in {pizza.PizzaCookingTimeInMilliseconds / 1000} seconds");
                //Thread.Sleep((int)pizza.PizzaCookingTimeInMilliseconds);
                Thread.Sleep(_config.GetValue<int>("cookingInterval"));
                //_log.LogInformation($"{pizza.PizzaName} is ready!");
                sw.WriteLine($"{i}. {pizza.PizzaName}");
            }

            sw.Close();
            _log.LogInformation("Thank you for your order!");
        }

        PizzaTopping CreateRandomTopping()
        {
            PizzaTopping[] toppings = { new HamAndMushroom(), new Pepperoni(), new Vegetable() };

            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];
        }

        PizzaBase CreateRandomBase()
        {
            PizzaBase[] bases = { new ThinAndCrispy(), new DeepPan(), new StuffedCrust() };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }

        public Pizza CreateRandomPizza() => new Pizza(CreateRandomBase(), CreateRandomTopping());
    }
}
