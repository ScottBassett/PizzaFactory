using ScottsPizzaFactory.DataAccess.Models.Bases;
using ScottsPizzaFactory.DataAccess.Models.Toppings;

namespace ScottsPizzaFactory.DataAccess.Models.Pizza
{

    public class Pizza : IPizza
    {
        public Pizza(PizzaBase randomBase, PizzaTopping randomTopping)
        {
            PizzaName = randomBase.BaseName + " " + randomTopping.ToppingName;
            PizzaCookingTimeInMilliseconds = randomBase.CookingTime + randomTopping.CookingTime;
        }

        public string PizzaName { get; set; }
        public double PizzaCookingTimeInMilliseconds { get; set; }
        public PizzaBase PizzaBase { get; set; }
        public PizzaTopping PizzaTopping { get; set; }
        public double TotalCookingTime => PizzaBase.CookingTime + PizzaTopping.CookingTime;
    }




    //public class Pizza : IPizza
    //{
    //    public Pizza(PizzaBase pizzaBase, PizzaTopping pizzaTopping)
    //    {
    //        PizzaBase = pizzaBase;
    //        PizzaTopping = pizzaTopping;
    //    }

    //    public PizzaBase PizzaBase { get; set; }
    //    public PizzaTopping PizzaTopping { get; set; }
    //    public bool Cooked { get; set; }
    //    public string GetDescription() => $"{PizzaBase.BaseName} {PizzaTopping.ToppingName}";

    //}
}
