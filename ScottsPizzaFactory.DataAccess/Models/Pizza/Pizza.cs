﻿using ScottsPizzaFactory.DataAccess.Models.Bases;
using ScottsPizzaFactory.DataAccess.Models.Toppings;

namespace ScottsPizzaFactory.DataAccess.Models.Pizza
{
    public class Pizza : IPizza
    {
        public Pizza(PizzaBase pizzaBase, PizzaTopping pizzaTopping)
        {
            PizzaBase = pizzaBase;
            PizzaTopping = pizzaTopping;
        }

        public PizzaBase PizzaBase { get; set; }
        public PizzaTopping PizzaTopping { get; set; }
        public bool Cooked { get; set; }
        public string GetDescription() => $"{PizzaBase.BaseName} {PizzaTopping.ToppingName}";
        public double TotalCookingTime => PizzaBase.CookingTime + PizzaTopping.CookingTime;

    }
}
