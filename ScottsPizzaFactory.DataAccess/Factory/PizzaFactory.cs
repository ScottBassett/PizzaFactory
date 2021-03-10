using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using ScottsPizzaFactory.DataAccess.Models.Bases;
using ScottsPizzaFactory.DataAccess.Models.Pizza;
using ScottsPizzaFactory.DataAccess.Models.Toppings;
using ScottsPizzaFactory.DataAccess.Services;


namespace ScottsPizzaFactory.DataAccess.Factory
{
    public class PizzaFactory : IPizzaFactory
    {
        private readonly IConsoleWriter _consoleWriter;
        public PizzaFactory(IServiceProvider serviceProvider)
        {
            _consoleWriter = serviceProvider.GetService<IConsoleWriter>();
        }

        public void RunPizzaFactory()
        {
            var amountOfPizzas = 10;

            var pizzaList = new List<Pizza>();

            Console.WriteLine($"Welcome to pizza factory, {amountOfPizzas} pizzas coming up!");


            for (var i = 0; i < amountOfPizzas; i++)
            {
                var pizza = CreateRandomPizza();
                Console.WriteLine($"Your {pizza.PizzaName} pizza will be ready in {pizza.PizzaCookingTimeInMilliseconds} milliseconds");
                Thread.Sleep((int)pizza.PizzaCookingTimeInMilliseconds);
                Console.WriteLine($"{pizza.PizzaName} is ready!");
                pizzaList.Add(pizza);

                var sw = new StreamWriter("C:\\Temp\\PizzaList.txt");
                foreach (var finishedPizza in pizzaList)
                {
                    sw.WriteLine(finishedPizza.PizzaName);
                }

                sw.Close();

            }
            Console.WriteLine("Thank you for your order!");
        }

        PizzaTopping CreateRandomTopping()
        {
            PizzaTopping[] toppings = new PizzaTopping[]
            {
                new HamAndMushroom(), new Pepperoni(), new Vegetable()
            };

            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];
        }

        PizzaBase CreateRandomBase()
        {
            PizzaBase[] bases = new PizzaBase[]
            {
                new ThinAndCrispy(), new DeepPan(), new StuffedCrust()
            };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }

        public Pizza CreateRandomPizza() => new Pizza(CreateRandomBase(), CreateRandomTopping());
    }
}
